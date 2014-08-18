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
