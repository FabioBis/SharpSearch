using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SharpSearch
{
    /// <summary>
    /// Defines a list of Node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeList<T> : Collection<Node<T>>
    {
        // Constructors.
        public NodeList() : base() { }

        public NodeList(int size)
        {
            // Add the specified number of nodes.
            for (int i = 0; i < size; i++)
			{
			    base.Items.Add(default(Node<T>));
			}
        }


        /// <summary>
        /// Given a value of type T returns the node containing it.
        /// </summary>
        public Node<T> FindByValue(T value)
        {
            // Search for the value.
            foreach (Node<T> node in base.Items)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }

    }
}
