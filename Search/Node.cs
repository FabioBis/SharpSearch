using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpSearch
{
    /// <summary>
    /// Defines a tree node of type T.
    /// </summary>
    /// <typeparam name="T">The type of the tree.</typeparam>
    public class Node<T>
    {
        // Node data.
        private T data;
        // List of children nodes.
        private NodeList<T> children;


        // Constructors.
        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> children)
        {
            this.data = data;
            this.children = children;
        }


        /// <summary>
        /// The node implementation data.
        /// </summary>
        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }


        /// <summary>
        /// A list of children nodes.
        /// </summary>
        public NodeList<T> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }


        /// <summary>
        /// Returns if and only if the current node is a leaf
        /// (has no children).
        /// </summary>
        /// <returns></returns>
        public bool IsLeaf()
        {
            return children == null;
        }

    }
}
