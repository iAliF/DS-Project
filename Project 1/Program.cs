using System;
using Project_1.Notation;

namespace Project_1
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("<<< Project 1 >>>");
            var infix = new Infix("(a + b) * c - d");
            Console.WriteLine(infix.ToPrefix());
            Console.WriteLine("<<< Bye Bye >>>");
        }
    }
}