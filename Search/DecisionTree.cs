//
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

        /// <summary>
        /// Returns <code>true</code> if the given decision is taken
        /// into account building the decision tree, <code>false</code>
        /// otherwise.
        /// </summary>
        /// <param name="decision">The decision to take next.</param>
        /// <returns>Boolean value.</returns>
        public bool NextDecisionPlanned(Decision decision)
        {
            return root.NextDecisionPlanned(decision);
        }

        /// <summary>
        /// Returns the node representing the next choice point.
        /// </summary>
        /// <returns></returns>
        public DecisionTreeNode<T> GetNextChoicePoint()
        {
            return root.GetNextChoicePoint();
        }
    }
}
