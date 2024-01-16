using System;
using Project_2.GenList;
using Project_2.LinkList;

namespace Project_2
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("<<< Project 2 >>>");

            var sub = new GeneralizedList<int>();
            for (int i = 5; i < 8; i++)
            {
                sub.AddNode(NodeType.Atomic, i);
                sub.AddNode(NodeType.Atomic, 11);
            }

            var sublist = new GeneralizedList<int>();
            for (int i = 6; i > 2; i--)
            {
                sublist.AddNode(NodeType.Atomic, i);
            }

            sublist.AddNode(NodeType.SubList, sub);

            var list = new GeneralizedList<int>();
            list.AddNode(NodeType.Atomic, 1);
            list.AddNode(NodeType.SubList, sublist);
            list.AddNode(NodeType.Atomic, 10);
            
            list.Print();
            Console.WriteLine($"Depth: {list.Depth()}");
            Console.WriteLine($"Sum: {list.Sum()}");
            Console.WriteLine($"Length: {list.Length()}");
            Console.WriteLine($"Fetched Nodes: {string.Join(", ", list.FetchAllNodes())}");
            Console.Write("Sorted Data: ");
            list.SortedNodes().Print();
            
            Console.ReadKey();
        }
    }
}