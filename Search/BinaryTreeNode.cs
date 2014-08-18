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
