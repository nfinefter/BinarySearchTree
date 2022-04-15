using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public bool Add(T value)
        {
            Node<T> before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                {
                    after = after.LeftNode;
                }
                else if (value > after.Data)
                {
                    after = after.RightNode;
                }
                else
                {
                    return false;
                }
            }

            Node<T> newNode = new Node<T>();
            newNode.Data = value;

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                if (value < before.Data)
                {
                    before.LeftNode = newNode;
                }
                else
                {
                    before.RightNode = newNode;
                }
            }

            return true;
        }

        public Node<T> Find(T value)
        {
            return Find(value, Root);
        }

        public void Remove(T value)
        {
            Root = Remove(Root, value);
        }

        private Node<T> Remove(Node<T> parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data)
            {
                parent.LeftNode = Remove(parent.LeftNode, key);
            }
            else if (key > parent.Data)
            {
                parent.RightNode = Remove(parent.RightNode, key);
            }

            else
            {
                if (parent.LeftNode == null)
                {
                    return parent.RightNode;
                }
                else if (parent.RightNode == null)
                {
                    return parent.LeftNode;
                }
                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node<T> node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private Node<T> Find(T value, Node<T> parent)
        {
            if (parent != null)
            {
                if (value == parent.Data)
                {
                    return parent; 
                }
                if (value < parent.Data)
                {
                    return Find(value, parent.LeftNode);
                }
                else
                {
                    return Find(value, parent.RightNode);
                }
            }

            return null;
        }


    }
}
