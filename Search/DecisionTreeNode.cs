﻿//
// Copyright (c) 2014 Fabio Biselli - fabio.biselli.80@gmail.com
//
// This software is provided 'as-is', without any express or implied
// warranty. In no event will the authors be held liable for any damages
// arising from the use of this software.
//
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
//    1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
//
//    2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
//
//    3. This notice may not be removed or altered from any source
//    distribution.
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    /// <summary>
    /// Defines a node for a decision tree.
    /// </summary>
    /// <typeparam name="T">Environment in which to take a decision.</typeparam>
    public class DecisionTreeNode : Node<Decision>
    {
        // The number of children.
        private int branches = 0;

        // The selected decision node children.
        public int ChoosenChild = -1;

        /// <summary>
        /// Default constructor. Build an empty decision node.
        /// </summary>
        public DecisionTreeNode()
            : base()
        {
            base.Children = new NodeList<Decision>();
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
        public DecisionTreeNode(Decision decision)
            : base(decision, null)
        {
            base.Children = new NodeList<Decision>();
        }

        /// <summary>
        /// The decision that generated this node.
        /// </summary>
        public Decision LastMove
        {
            get { return base.Value; }
            set { base.Value = value; }
        }

        /// <summary>
        /// Returns the number of children.
        /// </summary>
        /// <returns></returns>
        public int GetBranches()
        {
            return branches;
        }

        /// <summary>
        /// Returns true if and only if a decision was made and thus
        /// a children decision node is choosen.
        /// </summary>
        /// <returns></returns>
        public bool DecisionMade()
        {
            return ChoosenChild != -1;
        }

        /// <summary>
        /// Resets the decision made on this node.
        /// </summary>
        public void ResetDecision()
        {
            ChoosenChild = -1;
        }

        /// <summary>
        /// Resets all the decisions taken from this node.
        /// </summary>
        public void ResetDecisions()
        {
            resetDecisionsRec();
        }

        /// <summary>
        /// Recursive method that resets all decision taken.
        /// </summary>
        private void resetDecisionsRec()
        {
            if (ChoosenChild == -1)
            {
                // Base: no decision to reset.
                return;
            }
            else
            {
                // Recursive: resets the decision and make recursion
                // on the choosen node.
                int index = ChoosenChild;
                ChoosenChild = -1;
                DecisionTreeNode next =
                    (DecisionTreeNode)base.Children.ElementAt(index);
                next.resetDecisionsRec();
            }
        }

        /// <summary>
        /// Returns the only child of this node, if there is no children
        /// or there are more than one return null.
        /// </summary>
        /// <returns>The only child of this node.</returns>
        public DecisionTreeNode GetOnlyChild()
        {
            if (branches == 1)
            {
                return (DecisionTreeNode)base.Children.First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the choosen decision node from the children.
        /// </summary>
        /// <returns>The choosen decision node.</returns>
        public DecisionTreeNode GetChoosenChildren()
        {
            if (ChoosenChild == -1)
            {
                throw new NullReferenceException();
            }
            else
            {
                return (DecisionTreeNode)base.Children.ElementAt(ChoosenChild);
            }
        }

        /// <summary>
        /// Add a new child (a leaf) to the current node.
        /// </summary>
        /// <param name="data">The data contained in the new node.</param>
        public void AddChild(DecisionTreeNode node)
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
        public bool RemoveBranch(Decision decision)
        {
            if (base.Children == null)
            {
                return false;
            }

            DecisionTreeNode node =
                (DecisionTreeNode)base.Children.FindByValue(decision);
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
        /// Removes all children but the one given by the index.
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

        /// <summary>
        /// Make a decision and cut the tree removing all unnecessary branches.
        /// </summary>
        /// <param name="index">The index of the choosen decision node.</param>
        public void MakePermaDecision(int index)
        {
            if (branches == 0 || branches == 1)
            {
                throw new NullReferenceException();
            }
            else if (index < 0 || index > branches)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                removeAllButAt(index);
                ChoosenChild = index;
            }
        }

        /// <summary>
        /// Make a decision without removing nodes from the tree.
        /// </summary>
        /// <param name="index">The index of the choosen decision node.</param>
        public void MakeDecision(int index)
        {
            if (branches == 0)
            {
                throw new NullReferenceException();
            }
            else if (index < 0 || index > branches)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                ChoosenChild = index;
            }
        }

        /// <summary>
        /// This method explores the node children in depth until multiple
        /// decision are possible. Then given the heuristic select a decision
        /// and cut all the discarded branches.
        /// </summary>
        /// <param name="h">The heursitic for the decision to take.</param>
        /// <returns>The decision made.</returns>
        internal void NextPermaDecision(int index)
        {
            if (branches == 0)
            {
                // Base: this is a leaf no more decision should be expected.
                throw new NullReferenceException();
            }
            else if (index < 0 || index > branches)
            {
                throw new IndexOutOfRangeException();
            }
            else if (branches > 1)
            {
                // Base: multiple children, a decision is needed.
                MakePermaDecision(index);
            }
            else
            {
                // Recursive: only child, no decision needed at this level.
                this.GetOnlyChild().NextPermaDecision(index);
            }
        }

        /// <summary>
        /// This method explores the node children in depth until multiple
        /// decision are possible. Then given the heuristic selects a decision.
        /// </summary>
        /// <returns>The decision made.</returns>
        internal void NextDecision(int index)
        {
            if (branches == 0)
            {
                // Base: this is a leaf no more decision should be expected.
                throw new NullReferenceException();
            }
            else if (ChoosenChild == -1)
            {
                // Base: multiple children, a decision is needed.
                MakeDecision(index);
            }
            else
            {
                // Recursive: no decision needed at this level.
                this.GetChoosenChildren().NextDecision(index);
            }
        }

        /// <summary>
        /// This method explores the node children in depth until multiple
        /// decision are possible. Then applies the external decision cutting
        /// the discarded branches.
        /// </summary>
        /// <param name="decision">The external decision to be applied.</param>
        public void ExternalPermaDecisionMade(Decision decision)
        {
            if (branches == 0)
            {
                // last possible decision, nothing to do.
                return;
            }
            else if (branches == 1)
            {
                // Recursive: only child, the decision does not refer to this level.
                this.GetOnlyChild().ExternalPermaDecisionMade(decision);
            }
            else
            {
                // Base: multiple children, a decision is taken.
                int index = -1;
                foreach (DecisionTreeNode node in base.Children.ToList())
                {
                    if (decision.GetImpl().Equals(node.LastMove.GetImpl()))
                    {
                        index = base.Children.IndexOf(node);
                    }
                }
                ChoosenChild = index;
                removeAllButAt(index);
            }
        }

        /// <summary>
        /// This method explores the node children in depth until multiple
        /// decision are possible. Then applies the external decision.
        /// </summary>
        /// <param name="decision">The external decision to be applied.</param>
        public void ExternalDecisionMade(Decision decision)
        {
            if (branches == 0)
            {
                // last possible decision, nothing to do.
                return;
            }
            else if (ChoosenChild != -1)
            {
                // Recursive: the decision does not refer to this level.
                this.GetChoosenChildren().ExternalDecisionMade(decision);
            }
            else
            {
                // Base: multiple children, a decision is taken.
                int index = -1;
                foreach (DecisionTreeNode node in base.Children.ToList())
                {
                    if (decision.GetImpl().Equals(node.LastMove.GetImpl()))
                    {
                        index = base.Children.IndexOf(node);
                    }
                }
                ChoosenChild = index;
            }
        }

        /// <summary>
        /// Checks if the current node has no more children.
        /// </summary>
        /// <returns>
        /// true if the current node is a leaf, false otherwise.
        /// </returns>
        public new bool IsLeaf()
        {
            return branches == 0;
        }

        /// <summary>
        /// Returns <code>true</code> if the given decision is taken
        /// into account building the decision tree, <code>false</code>
        /// otherwise.
        /// </summary>
        /// <param name="decision"></param>
        internal bool NextDecisionPlanned(Decision decision)
        {
            if (branches == 0)
            {
                // Leaf, no decision can be made here.
                return false;
            }
            else if (ChoosenChild != -1)
            {
                // Recursive: the decision does not refers to this level.
                return this.GetChoosenChildren().NextDecisionPlanned(decision);
            }
            else
            {
                // Base: multiple children, a decision could be taken..
                int index = -1;
                foreach (DecisionTreeNode node in base.Children.ToList())
                {
                    if (decision.GetImpl().Equals(node.LastMove.GetImpl()))
                    {
                        index = base.Children.IndexOf(node);
                    }
                }
                return index != -1;
            }
        }

        /// <summary>
        /// Returns the node representing the next choice point.
        /// </summary>
        internal DecisionTreeNode GetNextChoicePoint()
        {
            if (branches == 0)
            {
                // Leaf, no decision can be made here.
                return null;
            }
            else if (ChoosenChild != -1)
            {
                // Recursive: the decision does not refers to this level.
                return this.GetChoosenChildren().GetNextChoicePoint();
            }
            else
            {
                return this;
            }
        }
    }
}
