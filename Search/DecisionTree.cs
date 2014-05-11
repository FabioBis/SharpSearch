using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    public class DecisionTree<T>
    {

        private DecisionTreeNode<T> root;


        public DecisionTree()
        {
            root = null;
        }


        public DecisionTree(T data, Decision decision)
        {
            root = new DecisionTreeNode<T>(data, decision);
        }


        public void MakePermaDecision(int index)
        {
            root.NextPermaDecision(index);
        }


        public void MakeDecision(int index)
        {
            root.NextDecision(index);
        }


        public void ResetDecisions()
        {
            root.ResetDecisions();
        }


        public void ExternalPermaDecisionMade(Decision decision)
        {
            root.ExternalPermaDecisionMade(decision);
        }


        public void ExternalDecisionMade(Decision decision)
        {
            root.ExternalDecisionMade(decision);
        }


        public DecisionTreeNode<T> GetRoot()
        {
            return root;
        }
    }
}
