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

        public int ChildrenCount
        {
            get
            {
                int count = 0;
                if (LeftChild != null)
                    count++;
                if (RightChild != null)
                    count++;
                return count;
            }
        }

        public void AddChild(int data)
        {
            if (LeftChild == null)
                LeftChild = new TreeNode(data);
            else if (RightChild == null)
                RightChild = new TreeNode(data);
            else
                if (LeftChild.ChildrenCount <= RightChild.ChildrenCount)
                    LeftChild.AddChild(data);
                else
                    RightChild.AddChild(data);
        }
    }
}