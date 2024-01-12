using System;
using Project_2.GenList;

namespace Project_2
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("<<< Project 2 >>>");

            var sublist = new GeneralizedList<int>();
            sublist.AddNode(NodeType.Atomic, 2);
            sublist.AddNode(NodeType.Atomic, 3);
            sublist.AddNode(NodeType.Atomic, 4);
            sublist.Print();
            Console.WriteLine();

            var list = new GeneralizedList<int>();
            list.AddNode(NodeType.Atomic, 1);
            list.AddNode(NodeType.SubList, sublist);
            list.AddNode(NodeType.Atomic, 5);
            list.Print();
        }
    }
}