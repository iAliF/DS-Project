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

        public void AddChild(TreeNode node)
        {
            node.Parent = this;
            
            if (LeftChild == null)
                LeftChild = node;
            else if (RightChild == null)
                RightChild = node;
            else if (LeftChild.ChildrenCount <= RightChild.ChildrenCount)
                LeftChild.AddChild(node);
            else
                RightChild.AddChild(node);
        }

        public void AddChild(int data)
        {
            AddChild(new TreeNode(data));
        }

        public void RemoveChild(TreeNode node)
        {
            if (LeftChild == node)
                LeftChild = null;
            if (RightChild == node)
                RightChild = null;
        }
    }
}