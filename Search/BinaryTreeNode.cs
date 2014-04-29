using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data,
                              BinaryTreeNode<T> left,
                              BinaryTreeNode<T> right)
        {
            base.Value = data;
            NodeList<T> sons = new NodeList<T>(2);
            sons[0] = left;
            sons[1] = right;
            base.Children = sons;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Children == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode<T>) base.Children[0];
                }
            }

            set
            {
                if (base.Children == null)
                {
                    base.Children = new NodeList<T>(2);
                }
                base.Children[0] = value;
            }
        }


        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Children == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode<T>)base.Children[1];
                }
            }

            set
            {
                if (base.Children == null)
                {
                    base.Children = new NodeList<T>(2);
                }
                base.Children[1] = value;
            }
        }

    }
}
