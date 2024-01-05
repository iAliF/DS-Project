using System;
using Project_1.Notation;

namespace Project_1
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("==== Infix =====");
            var infix = new Infix("(a + b) * c - d");

            Console.WriteLine($"Value: {infix.Value}");
            Console.WriteLine($"PostFix: {infix.ToPostFix().Value}");
            Console.WriteLine($"Prefix: {infix.ToPrefix().Value}");
            
            Console.WriteLine("\n==== Postfix =====");
            var postfix = new Postfix("ab*c+");

            Console.WriteLine($"Value: {postfix.Value}");
            Console.WriteLine($"Infix: {postfix.ToInfix().Value}");
            Console.WriteLine($"Prefix: {postfix.ToPrefix().Value}");
            
            Console.WriteLine("\n==== Prefix =====");
            var prefix = new Prefix("-*+abcd");

            Console.WriteLine($"Value: {prefix.Value}");
            Console.WriteLine($"Infix: {prefix.ToInfix().Value}");
            Console.WriteLine($"Postfix: {prefix.ToPostfix().Value}");
        }
    }
}