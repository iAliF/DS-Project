﻿using System;

namespace Project_3.Tree
{
    public class BinaryTree
    {
        private TreeNode _root;

        public TreeNode Root => _root;

        public BinaryTree()
        {
            _root = null;
        }

        public BinaryTree(int data)
        {
            _root = new TreeNode(data);
        }

        public BinaryTree(TreeNode root)
        {
            _root = root;
        }

        public BinaryTree(int[] data)
        {
            foreach (var x in data)
                Add(x);
        }

        public void Add(int data)
        {
            Add(new TreeNode(data));
        }

        public void Add(TreeNode node)
        {
            if (_root == null)
            {
                _root = node;
                return;
            }
            _root.AddChild(node);
        }

        public TreeNode DeleteNode(TreeNode node)
        {
            return DeleteNode(node, node);
        }

        public TreeNode DeleteNode(TreeNode thisNode, TreeNode delNode)
        {
            if (thisNode.ChildrenCount == 0) // We Find a leaf and swap it's data with the node we want to delete
            {
                thisNode.Parent.RemoveChild(thisNode);
                delNode.Data = thisNode.Data;
                return delNode;
            }

            if (thisNode.LeftChild != null)
                return DeleteNode(thisNode.LeftChild, delNode);

            return DeleteNode(thisNode.RightChild, delNode);
        }

        public void DeleteNodeByData(int data)
        {
            DeleteNodeByData(data, _root);
        }

        public void DeleteNodeByData(int data, TreeNode node)
        {
            if (node == null) return;

            if (node.Data == data)
                DeleteNode(node);

            DeleteNodeByData(data, node.LeftChild);
            DeleteNodeByData(data, node.RightChild);
        }

        public int Sum(TreeNode node = null)
        {
            if (node == null)
                node = _root; // Start from root

            var sum = node.Data;
            if (node.LeftChild != null)
                sum += Sum(node.LeftChild);
            if (node.RightChild != null)
                sum += Sum(node.RightChild);

            return sum;
        }

        public int Levels()
        {
            return Levels(_root); // Start from root
        }

        public int Levels(TreeNode node)
        {
            if (node == null)
                return 0;

            var l = Levels(node.LeftChild);
            var r = Levels(node.RightChild);
            var max = l > r ? l : r;

            return max + 1;
        }

        public int NodesCount()
        {
            return NodesCount(_root); // Start from root
        }

        public int NodesCount(TreeNode node)
        {
            if (node == null)
                return 0;

            return NodesCount(node.RightChild) + NodesCount(node.LeftChild) + 1;
        }

        public int LeavesCount()
        {
            return LeavesCount(_root); // Start from root
        }

        public int LeavesCount(TreeNode node)
        {
            // Node doesn't exist (Link to child is null)
            if (node == null)
                return 0;

            // If node hasn't any child => It's a leaf
            if (node.ChildrenCount == 0)
                return 1; // This method returns 1 every time it finds a leaf (leaves count => sum of these ones)

            // Sum of leaves of left/right child
            return LeavesCount(node.RightChild) + LeavesCount(node.LeftChild);
        }

        public void PreOrder()
        {
            PreOrder(_root); // Start from root
            Console.WriteLine(); // Write a new line when it's done.
        }

        public void PreOrder(TreeNode node)
        {
            if (node == null)
                return;

            // PreOrder => VLR
            Console.Write($"{node.Data} "); // Add space between each data for better readability
            PreOrder(node.LeftChild);
            PreOrder(node.RightChild);
        }

        public void InOrder()
        {
            InOrder(_root); // Start from root
            Console.WriteLine(); // Write a new line when it's done.
        }

        public void InOrder(TreeNode node)
        {
            if (node == null)
                return;

            // InOrder => LVR
            InOrder(node.LeftChild);
            Console.Write($"{node.Data} ");
            InOrder(node.RightChild);
        }

        public void PostOrder()
        {
            PostOrder(_root); // Start from root
            Console.WriteLine(); // Write a new line when it's done.
        }

        public void PostOrder(TreeNode node)
        {
            if (node == null)
                return;

            // PostOrder => LRV
            PostOrder(node.LeftChild);
            PostOrder(node.RightChild);
            Console.Write($"{node.Data} ");
        }
    }
}