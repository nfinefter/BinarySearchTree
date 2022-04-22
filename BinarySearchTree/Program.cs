using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree!");

            Tree<int> binaryTree = new Tree<int>();
            Node<int> test = new Node<int>(60);

            binaryTree.Add(50);
            binaryTree.Add(60);
            binaryTree.Add(40);
            binaryTree.Add(30);
            binaryTree.Add(45);
            binaryTree.Add(65);
            binaryTree.Add(25);
            binaryTree.Add(55);

            bool didRemove = binaryTree.Remove(test);

            Console.WriteLine(didRemove);
            //check if the two child delete works properly
            
        }
    }
}
