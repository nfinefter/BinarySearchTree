using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree!");

            Tree<int> binaryTree = new Tree<int>();


            binaryTree.Add(5);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(3);


            //for (int i = 0; i < 1500000; i++)
            //{
            //    binaryTree.Add(i);
            //}
            //WORKS atleast at home no stack overflow
        }
    }
}
