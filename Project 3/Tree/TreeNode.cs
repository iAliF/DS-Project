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
    }
}