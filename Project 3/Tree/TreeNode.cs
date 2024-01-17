using System;

namespace Project_3.Tree
{
    public class TreeNode
    {
        public int Data;
        public TreeNode Parent;
        public TreeNode LeftChild;
        public TreeNode RightChild;

        public TreeNode(int data = 0, TreeNode parent = null, TreeNode leftChild = null, TreeNode rightChild = null)
        {
            Data = data;
            Parent = parent;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public void AddChild(int data)
        {
            if (LeftChild == null)
                LeftChild = new TreeNode(data);
            else if (RightChild == null)
                RightChild = new TreeNode(data);
            else
                Console.WriteLine("Cannot add child to this node ...");
        }
    }
}