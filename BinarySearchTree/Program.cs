using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree!");

            Tree<int> binaryTree = new Tree<int>();
            Node<int> test = new Node<int>(60);
            List<Node<int>> list = new List<Node<int>>();


            binaryTree.Add(50);
            binaryTree.Add(60);
            binaryTree.Add(40);
            binaryTree.Add(30);
            binaryTree.Add(45);
            binaryTree.Add(65);
            binaryTree.RecursiveAdd(25);

            list = binaryTree.InOrderRecursive();
            list = binaryTree.PostOrderRecursive();
            test = binaryTree.FindRecursive(25);

            Console.WriteLine(test.Data);

            for (int i = 0; i < list.Count; i++)
            {
                
                Console.WriteLine(list[i].Data);
            }
        }
    }
}
