using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    public class DecisionTreeNode<T> : Node<T>
    {
        // The number of childdren.
        private int branches = 0;

        // The decision that generated this node.
        private Decision decision;


        /// <summary>
        /// Default constructor. Build an empty decision node.
        /// </summary>
        public DecisionTreeNode()
            : base()
        {
            base.Children = new NodeList<T>();
        }


        /// <summary>
        /// Constructor with two parameters.
        /// A DecisionTreeNode must always be built with this two components:
        /// the current state of the problem and the decision taken to
        /// produce it.
        /// </summary>
        /// <param name="data">The problem state</param>
        /// <param name="decision">The last decision that made this problem
        /// state.</param>
        public DecisionTreeNode(T data, Decision decision)
            : base(data, null)
        {
            this.decision = decision;
            base.Children = new NodeList<T>();
        }


        public int GetBranches()
        {
            return branches;
        }


        public Decision LastMove
        {
            get { return decision; }
            set { decision = value; }
        }


        /// <summary>
        /// Return the only child of this node, if there is no children
        /// or there are more than one return null.
        /// </summary>
        /// <returns>The only child of this node.</returns>
        public DecisionTreeNode<T> GetOnlyChild()
        {
            if (branches == 1)
            {
                return (DecisionTreeNode<T>) base.Children.First();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Add a new child (a leaf) to the current node.
        /// </summary>
        /// <param name="data">The data contained in the new node.</param>
        public void AddChild(DecisionTreeNode<T> node)
        {
            base.Children.Add(node);
            branches++;
        }


        /// <summary>
        /// This method removes a node from the Children list.
        /// Within another point of view the method cut a branch from a tree
        /// that grows from the current node.
        /// The branch removed is identified by the data (which should be a
        /// problem state unique in the current subtree) to be discared.
        /// </summary>
        /// <param name="data">The proble state to be discared.</param>
        /// <returns>true if the node is correctly removed, false otherwise.</returns>
        public bool RemoveBranch(T data)
        {
            if (base.Children == null)
            {
                return false;
            }

            DecisionTreeNode<T> node =
                (DecisionTreeNode<T>)base.Children.FindByValue(data);
            if (base.Children.Remove(node))
            {
                branches--;
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Remove all children but the one given by the index.
        /// </summary>
        /// <param name="index">The index to the node List not to remove.</param>
        private void removeAllButAt(int index)
        {
            if (index == -1)
            {
                return;
            }
            int i = branches - 1;
            while (i >= 0)
            {
                if (i != index)
                {
                    base.Children.RemoveAt(i);
                    branches--;
                }
                i--;
            }
        }


        public void MakeDecision(int index)
        {
            if (branches == 0 || branches == 1)
            {
                throw new NullReferenceException();
            }
            else
            {
                removeAllButAt(index);
            }
        }


        /// <summary>
        /// This method explores the node children in depth until
        /// multiple decision are possible. Than given the heuristic
        /// select a decision and cut all the discared branches.
        /// </summary>
        /// <param name="h">The heursitic for the decision to take.</param>
        /// <returns>The decision made.</returns>
        internal void NextDecision(int index)
        {
            if (branches == 0)
            {
                // Base: this is a leaf no more decision should be expected.
                throw new NullReferenceException();
            }
            else if (branches > 1)
            {
                // Base: multiple children, a decision is needed.
                MakeDecision(index);
            }
            else
            {
                // Recursive: only child, no decision needed at this level.
                this.GetOnlyChild().NextDecision(index);
            }
        }


        public void ExternalDecisionMade(Decision decision)
        {
            if (branches == 0)
            {
                // last possible decision, nothing to do.
                return;
            }
            else if (branches == 1)
            {
                // Recursive: only child, the decision does not refer to this level.
                this.GetOnlyChild().ExternalDecisionMade(decision);
            }
            else
            {
                // Base: multiple children, a decision is taken.
                int index = -1;
                foreach (DecisionTreeNode<T> node in base.Children.ToList())
                {
                    if (decision.GetImpl().Equals(node.LastMove.GetImpl()))
                    {
                        index = base.Children.IndexOf(node);
                    }
                }
                removeAllButAt(index);
            }
        }

        /// <summary>
        /// Check if the current node has no more child.
        /// </summary>
        /// <returns>
        /// true if the current node is a leaf, false otherwise.
        /// </returns>
        public new bool IsLeaf()
        {
            return branches == 0;
        }

    }
}
