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


        public void MakeDecision(int index)
        {
            root.NextDecision(index);
        }

        public DecisionTreeNode<T> GetRoot()
        {
            return root;
        }
    }
}
