using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace SharpSearch
{
    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int size)
        {
            // Add the specified number of nodes.
            for (int i = 0; i < size; i++)
			{
			    base.Items.Add(default(Node<T>));
			}
        }

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
