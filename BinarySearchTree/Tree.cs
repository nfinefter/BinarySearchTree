using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Tree
    {
        private Node root;

        private Node GetSuccessor(Node node)
        {
            Node parentOfSuccessor = node;
            Node successor = node;
            Node current = node.RightNode;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;
            }
            if (successor != node.RightNode)
            {
                parentOfSuccessor.LeftNode = successor.RightNode;
                successor.RightNode = node.RightNode;
            }
            successor.LeftNode = node.LeftNode;
            return successor;

        }

        public Node Find(int data)
        {
            if (root != null)
            {
                return root.Find(data);
            }    
            else
            {
                return null;
            }
        }
        public Nullable<int> Minimum()
        {
            if (root != null)
            {
                return root.Minimum();
            }
            else
            {
                return null;
            }
        }
        public Nullable<int> Maximum()
        {
            if (root != null)
            {
                return root.Maximum();
            }
            else
            {
                return null;
            }
        }

        public void Insert(int data)
        {
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                root = new Node(data);
            }
        }
        public void Delete(int data)
        {
            Node current = root;
            Node parent = root;
            bool isLeftChild = false;

            if (current == null)
            {
                return;
            }
            while (current != null && current.Data != data)
            {
                parent = current;

                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
                
            }
            if (current == null)
            {
                return;
            }
            if (current.RightNode == null && current.LeftNode == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = null;
                    }
                    else
                    {
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null)
            {
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.LeftNode == null)
            {
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else
            {
                Node successor = GetSuccessor(current);
                
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = successor;
                }
                else
                {
                    parent.RightNode = successor;
                }
            }
        }

    }
}
