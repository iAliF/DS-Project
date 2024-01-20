using System;
using Project_3.Tree;

namespace Project_3
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("<<< Project 3 >>>");

            var root = new TreeNode(1);
            // var lc = new TreeNode(2);
            // var rc = new TreeNode(3);
            // rc.RightChild = new TreeNode(5);
            // rc.RightChild.RightChild = new TreeNode(6);
            // rc.RightChild.RightChild.LeftChild = new TreeNode(4);
            // root.LeftChild = lc;
            // root.RightChild = rc;
            // lc.LeftChild = new TreeNode(7);
            // lc.RightChild = new TreeNode(8);
            // lc.RightChild.RightChild = new TreeNode(10);
            var tree = new BinaryTree(root);
            tree.Add(2);
            tree.Add(3);
            tree.Add(2);
            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(6);
            tree.Add(7);
            tree.Add(2);
            tree.Add(8);
            tree.Add(9);
            var d = new TreeNode(10);
            tree.Add(d);
            // Console.WriteLine(tree.LeavesCount());
            tree.PreOrder();
            tree.DeleteNodeByData(2);
            tree.PreOrder();

            var t = new BinaryTree(new int[] { 1, 2, 5, 6, 7, 8, 9 });
            t.PreOrder();
        }
    }
}