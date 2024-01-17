namespace Project_3.Tree
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
    }
}