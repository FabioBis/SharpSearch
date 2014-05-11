using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    /// <summary>
    /// Defines a decision tree.
    /// </summary>
    /// <typeparam name="T">Environment in which to take a decision.</typeparam>
    public class DecisionTree<T>
    {
        // The root node.
        private DecisionTreeNode<T> root;

        // Constructors.
        public DecisionTree()
        {
            root = null;
        }


        public DecisionTree(T data, Decision decision)
        {
            root = new DecisionTreeNode<T>(data, decision);
        }


        /// <summary>
        /// Make a permanent decision cutting the unnecessary branches
        /// of the tree. This method explores the tree in depth until
        /// a node without a decision taken is reached, then applies the
        /// decision removing all but the children indexed by the given
        /// index.
        /// </summary>
        /// <param name="index">The index of the choosen children node.</param>
        public void MakePermaDecision(int index)
        {
            root.NextPermaDecision(index);
        }


        /// <summary>
        /// Make a decision without cutting the tree. This method explores the
        /// tree in depth until a node without a decision taken is reached,
        /// then applies the decision keepeing all the children nodes.
        /// </summary>
        /// <param name="index">The index of the choosen children node.</param>
        public void MakeDecision(int index)
        {
            root.NextDecision(index);
        }


        /// <summary>
        /// Resets all the decisions taken for this tree.
        /// </summary>
        public void ResetDecisions()
        {
            root.ResetDecisions();
        }


        /// <summary>
        /// Applies an external decision to the tree. This method explores
        /// the tree in depth until a node without a decision taken is reached,
        /// then applies the decision removing all but the children indexed by
        /// the given decision.
        /// </summary>
        /// <param name="decision">The external decision to be applied.</param>
        public void ExternalPermaDecisionMade(Decision decision)
        {
            root.ExternalPermaDecisionMade(decision);
        }


        /// <summary>
        /// Applies an external decision to the tree. This method explores
        /// the tree in depth until a node without a decision taken is reached,
        /// then applies the given decision keepeing all the children nodes.
        /// </summary>
        /// <param name="decision">The external decision to be applied.</param>
        public void ExternalDecisionMade(Decision decision)
        {
            root.ExternalDecisionMade(decision);
        }


        /// <summary>
        /// Returns the root node.
        /// </summary>
        /// <returns>The root node.</returns>
        public DecisionTreeNode<T> GetRoot()
        {
            return root;
        }
    }
}
