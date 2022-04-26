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

            if (curr == null) return null;

            List<Node<T>> nodes = new List<Node<T>>();

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



            //while (curr != null)
            //{
            //    while (curr.LeftNode != null)
            //    {
            //        stack.Push(curr);

            //        curr = curr.LeftNode;
            //    }
            //    while (curr.RightNode == null)
            //    {
            //        Node<T> item = stack.Pop();

            //        nodes.Add(item);

            //        curr = item;
            //    }
            //    while (curr.RightNode != null)
            //    {
            //        curr = curr.RightNode;
            //        nodes.Add(curr);
            //    }
            //    curr = curr.LeftNode;
            //}

            //Fix traversal
            return nodes;
        }

        public void Add(T value)
        {
            Node<T> temp = new Node<T>(value);

            if(Root == null)
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
                    if(current.RightNode == null)
                    {
                        current.RightNode = temp;
                        return;
                    }
                    current = current.RightNode;
                }
            }
        }

        public Node<T> FindMin(Node<T> root)
        {
            Node<T> curr = root;
            if (curr.LeftNode == null) return root;
         
            while (curr.LeftNode != null)
            {
                curr = curr.LeftNode;
            }    

            return curr;

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
        private void DeleteTwoChild (Node<T> node)
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

            return;
        }
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
                            current.LeftNode = null;
                            return true;
                        }
                        else if (current.LeftNode.LeftNode == null && current.LeftNode.RightNode != null) // 1 child
                        {
                            current.LeftNode = current.LeftNode.RightNode;
                            return true;
                        }
                        else if (current.LeftNode.LeftNode != null && current.LeftNode.RightNode == null) // 1 child
                        {
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
                            current.RightNode = null;
                            return true;
                        }
                        else if (current.RightNode.LeftNode == null && current.RightNode.RightNode != null) // 1 child
                        {
                            current.RightNode = current.RightNode.RightNode;
                            return true;
                        }
                        else if (current.RightNode.LeftNode != null && current.RightNode.RightNode == null) // 1 child
                        {
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
    }
}
