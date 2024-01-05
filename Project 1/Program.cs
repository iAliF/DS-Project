using System;
using System.Collections.Generic;
using Project_1.Notation;

namespace Project_1
{
    internal static class Program
    {
        private static readonly string[] _options =
        {
            "Infix to Prefix",
            "Infix to Postfix",
            "Prefix to Infix",
            "Prefix to Postfix",
            "Postfix to Infix",
            "Postfix to Prefix",
            "Exit"
        };

        private static string GetHelpText()
        {
            var output = "";
            for (int i = 0; i < _options.Length; i++)
                output += $"{i + 1}. {_options[i]}\n";

            return output;
        }

        private static int GetOption()
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var option) && option >= 1 && option <= 7)
                    return option;

                Console.WriteLine("Invalid input.");
            }
        }

        public static void Main()
        {
            var helpText = GetHelpText();
            Console.WriteLine(helpText);

            int option;
            while ((option = GetOption()) != 7)
            {
                Console.WriteLine($"You chose option {option}.");
            }

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}