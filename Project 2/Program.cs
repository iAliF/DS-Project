using System;
using Project_2.GenList;

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
            }

            var sublist = new GeneralizedList<int>();
            for (int i = 2; i < 5; i++)
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

            Console.ReadKey();
        }
    }
}