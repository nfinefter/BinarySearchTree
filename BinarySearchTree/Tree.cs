using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public List<Node<T>> InOrderTraversal()
        {
            Node<T> curr = Root;

            List<Node<T>> nodes = new List<Node<T>>();

            if (curr == null) return nodes;

            Stack<Node<T>> stack = new Stack<Node<T>>();

            while (curr != null || stack.Count != 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.LeftNode;
                }
                curr = stack.Pop();
                nodes.Add(curr);
                curr = curr.RightNode;
            }
            return nodes;
        }

        public List<Node<T>> PreOrderTransversal()
        {
            Node<T> curr = Root;

            List<Node<T>> nodes = new List<Node<T>>();

            if (curr == null) return nodes;

            Stack<Node<T>> stack = new Stack<Node<T>>();

            stack.Push(Root);

            while (stack.Count != 0)
            {
                curr = stack.Pop();

                nodes.Add(curr);

                if (curr.RightNode != null)
                {
                    stack.Push(curr.RightNode);
                }
                if (curr.LeftNode != null)
                {
                    stack.Push(curr.LeftNode);
                }
            }

            return nodes;
        }

        public List<Node<T>> PreOrderRecursive()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            PreOrderRecursive(Root, nodes);
            return nodes;
        }

        private void PreOrderRecursive(Node<T> curr, List<Node<T>> nodes)
        {
            if (curr == null) return;
            nodes.Add(curr);

            PreOrderRecursive(curr.LeftNode, nodes);
            PreOrderRecursive(curr.RightNode, nodes);
        }

        public List<Node<T>> InOrderRecursive()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            InOrderRecursive(Root, nodes);
            return nodes;
        }

        private void InOrderRecursive(Node<T> curr, List<Node<T>> nodes)
        {
            if (curr == null) return;
          
            InOrderRecursive(curr.LeftNode, nodes);
            nodes.Add(curr);
            InOrderRecursive(curr.RightNode, nodes);
        }

        public List<Node<T>> PostOrderRecursive()
        {
            List<Node<T>> nodes = new List<Node<T>>();
            PostOrderRecursive(Root, nodes);
            return nodes;
        }

        private void PostOrderRecursive(Node<T> curr, List<Node<T>> nodes)
        {
            if (curr == null) return;

            PostOrderRecursive(curr.LeftNode, nodes);
            PostOrderRecursive(curr.RightNode, nodes);
            nodes.Add(curr);
        }

        public void Add(T value)
        {
            Node<T> temp = new Node<T>(value);

            if (Root == null)
            {
                Root = temp;
                return;
            }

            Node<T> current = Root;

            while (true)
            {
                if (value.CompareTo(current.Data) < 0)
                {
                    if (current.LeftNode == null)
                    {
                        current.LeftNode = temp;
                        return;
                    }
                    current = current.LeftNode;
                }
                else if (value.CompareTo(current.Data) >= 0)
                {
                    if (current.RightNode == null)
                    {
                        current.RightNode = temp;
                        return;
                    }
                    current = current.RightNode;
                }
            }
        }

        public void RecursiveAdd(T value)
        {
            Node<T> nodeToInsert = new Node<T>(value);
            
            if(Root == null)
            {
                Root = nodeToInsert;
                return;
            }
            
            RecursiveAdd(Root, nodeToInsert);
        }

        private void RecursiveAdd(Node<T> curr, Node<T> nodeToInsert)
        {          
            if (nodeToInsert.Data.CompareTo(curr.Data) >= 0)
            {  
                if (curr.RightNode == null)
                {
                    curr.RightNode = nodeToInsert;
                    return;
                }

                curr = curr.RightNode;
            }
            else
            {
                if (curr.LeftNode == null)
                {
                    curr.LeftNode = nodeToInsert;
                    return;
                }

                curr = curr.LeftNode;
            }

            RecursiveAdd(curr, nodeToInsert);
        }
        //TODO: make small functions for Remove

        public bool Remove(Node<T> node)
        {
            if (node == null) return false;

            Node<T> current = Root;

            while (current != null)
            {
                if (node.Data.CompareTo(current.Data) < 0)
                {
                    //current might be parent
                    if (current.LeftNode.Data.CompareTo(node.Data) == 0)
                    {
                        if (current.LeftNode.LeftNode == null && current.LeftNode.RightNode == null) // 0 child
                        {
                            DeleteLeaf(current, "left");
                            current.LeftNode = null;
                            return true;
                        }
                        else if (current.LeftNode.LeftNode == null && current.LeftNode.RightNode != null) // 1 child
                        {
                            DeleteOneChild(current.LeftNode, "lft");
                            current.LeftNode = current.LeftNode.RightNode;
                            return true;
                        }
                        else if (current.LeftNode.LeftNode != null && current.LeftNode.RightNode == null) // 1 child
                        {
                            DeleteOneChild(current.LeftNode, "left");
                            current.LeftNode = current.LeftNode.LeftNode;
                            return true;
                        }
                        else if (current.LeftNode.LeftNode != null && current.LeftNode.RightNode != null) // 2 child
                        {
                            DeleteTwoChild(current.LeftNode);
                        }
                        return true;
                    }
                    current = current.LeftNode;
                }
                else if (node.Data.CompareTo(current.Data) > 0)
                {
                    if (current.RightNode.Data.CompareTo(node.Data) == 0)
                    {
                        if (current.RightNode.LeftNode == null && current.RightNode.RightNode == null) // 0 child
                        {
                            DeleteLeaf(current, "right");
                            current.RightNode = null;
                            return true;
                        }
                        else if (current.RightNode.LeftNode == null && current.RightNode.RightNode != null) // 1 child
                        {
                            DeleteOneChild(current.RightNode, "right");
                            current.RightNode = current.RightNode.RightNode;
                            return true;
                        }
                        else if (current.RightNode.LeftNode != null && current.RightNode.RightNode == null) // 1 child
                        {
                            DeleteOneChild(current.RightNode, "right");
                            current.RightNode = current.RightNode.LeftNode;
                            return true;
                        }
                        else if (current.RightNode.LeftNode != null && current.RightNode.RightNode != null) // 2 children
                        {
                            DeleteTwoChild(current.RightNode);
                        }

                        return true;
                    }
                    current = current.RightNode;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
     

        public Node<T> FindBeforeMax(Node<T> root)
        {
            Node<T> curr = root;
            if (curr.RightNode == null) return root;

            while (curr.RightNode.RightNode != null)
            {
                curr = curr.RightNode;
            }

            return curr;
        }

        private void DeleteLeaf(Node<T> node, string direction)
        {
            if (direction == "left")
            {
                node.LeftNode = null;
            }
            if (direction == "right")
            {
                node.RightNode = null;
            }
        }

        private void DeleteOneChild(Node<T> node, string direction)
        {
            if (direction == "left")
            {
                if (node == null && node.RightNode != null)
                {
                    node = node.RightNode;
                    return;
                }
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node = node.LeftNode;
                    return;
                }

            }
            if (direction == "right")
            {
                if (node.LeftNode == null && node.RightNode != null)
                {
                    node = node.RightNode;
                    return;
                }
                else if (node.LeftNode != null && node.RightNode == null)
                {
                    node = node.LeftNode;
                    return;
                }
            }
        }

        private void DeleteTwoChild(Node<T> node)
        {
            Node<T> Replacer = FindBeforeMax(node.LeftNode);

            if (Replacer.RightNode == null)
            {
                node.Data = Replacer.Data;
                node.LeftNode = Replacer.LeftNode;
                return;
            }

            node.LeftNode.Data = Replacer.RightNode.Data;

            Replacer.RightNode = Replacer.RightNode.LeftNode;
        }

       

        public Node<T> Find(T value)
        {
            Node<T> current = Root;

            while (current != null)
            {
                if (current.Data.CompareTo(value) == 0) return current;

                if (value.CompareTo(current.Data) < 0)
                {
                    current = current.LeftNode;
                }
                else
                {
                    current = current.RightNode;
                }
            }

            return default;
        }

        public Node<T> FindRecursive(T value)
        {
            return FindRecursive(value, Root);
        }

        private Node<T> FindRecursive(T value, Node<T> curr)
        {
            if (curr == null) return null;

            if (curr.Data.CompareTo(value) == 0)
            {
                return curr;
            }
            else if (value.CompareTo(curr.Data) > 0)
            {
                return FindRecursive(value, curr.RightNode);
            }
            else
            {
                return FindRecursive(value, curr.LeftNode);
            }
        }
        public void RecursiveDel(T value)
        {
            RecursiveDel(Root, value);
        }

        private void RecursiveDel(Node<T> curr, T value)
        {

        }

        public Node<T> FindMin(Node<T> root)
        {
            Node<T> curr = root;

            while (curr.LeftNode != null)
            {
                curr = curr.LeftNode;
            }

            return curr;
        }
    }
}
