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

            binaryTree.Add(50);
            binaryTree.Add(60);
            binaryTree.Add(40);
            binaryTree.Add(30);
            binaryTree.Add(45);
            binaryTree.Add(65);
            binaryTree.Remove(45);

            List<Node<int>> list = binaryTree.PreOrderRecursive();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Data);
            }
        }
    }
}
