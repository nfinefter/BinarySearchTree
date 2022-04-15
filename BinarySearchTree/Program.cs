using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree!");

            Tree binaryTree = new Tree();

            for (int i = 0; i < 1500000; i++)
            {
                binaryTree.Add(i);
            }
           //WORKS atleast at home no stack overflow
        }
    }
}
