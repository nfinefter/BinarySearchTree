﻿using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree!");

            Tree<int> binaryTree = new Tree<int>();
            Node<int> test = new Node<int>(4);

            binaryTree.Add(6);
            binaryTree.Add(5);
            binaryTree.Add(7);
            binaryTree.Add(3);
            binaryTree.Add(13);
            binaryTree.Add(14);
            binaryTree.Add(4);
            binaryTree.Add(2);
            test = binaryTree.FindBeforeMax(binaryTree.Root);
            Console.WriteLine(test.Data);
            //Check Deletes
            test.Data = 3;
            bool didRemove = binaryTree.Remove(test);

            Console.WriteLine(didRemove);

            

            //int value = binaryTree.Find(3);

            //Console.WriteLine(value);

            //for (int i = 0; i < 1500000; i++)
            //{
            //    binaryTree.Add(i);
            //}
            //WORKS atleast at home no stack overflow
        }
    }
}
