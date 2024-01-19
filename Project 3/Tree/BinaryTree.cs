﻿namespace Project_3.Tree
{
    public class BinaryTree
    {
        private readonly TreeNode _root;

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

        public void Add(int data)
        {
            _root.AddChild(data);
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
    }
}