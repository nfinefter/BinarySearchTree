using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node
    {
        private int data;

        public int Data 
        {
            get { return data; }
        }


        private Node rightNode;

        public Node RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        private Node leftNode;

        public Node LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
        }

        public Node(int value)
        {
            data = value;
        }

        public void Delete()
        {
            isDeleted = true;
        }

        public Node Find(int value)
        {
            Node currentNode = this;
            while (currentNode != null)
            {
                if (value == currentNode.data && isDeleted == false)
                {
                    return currentNode;
                }
                else if (value > currentNode.data)
                {
                    currentNode = currentNode.rightNode;
                }
                else
                {
                    currentNode = currentNode.LeftNode;
                }
            }
            return null;
        }
        public void Insert(int value)
        {
            if (value >= data)
            {
                if (rightNode == null)
                {
                    rightNode = new Node(value);
                }
                else
                {
                    rightNode.Insert(value);
                }
            }
            else
            {
                if (leftNode == null)
                {
                    leftNode = new Node(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }
        public Nullable<int> Minimum()
        {
            if (leftNode == null)
            {
                return data;
            }
            else
            {
                return leftNode.Minimum();
            }
        }
        public Nullable<int> Maximum()
        {
            if (rightNode == null)
            {
                return data;
            }
            else
            {
                return rightNode.Maximum();
            }
        }
    }
}
