using System;
using System.Collections.Generic;
using Project_1.Notation;

namespace Project_1
{
    internal static class Program
    {
        // List of ValueTuples
        // Tuple => Name, From, To
        private static readonly (string name, NotationType from, NotationType to)[] _options =
        {
            ("Infix to Prefix", NotationType.Infix, NotationType.Prefix),
            ("Infix to Postfix", NotationType.Infix, NotationType.Prefix),
            ("Prefix to Infix", NotationType.Infix, NotationType.Prefix),
            ("Prefix to Postfix", NotationType.Infix, NotationType.Prefix),
            ("Postfix to Infix", NotationType.Infix, NotationType.Prefix),
            ("Postfix to Prefix", NotationType.Infix, NotationType.Prefix)
        };

        private static string GetHelpText()
        {
            var output = "";

            for (var i = 0; i < _options.Length; i++)
                output += $"{i + 1}. {_options[i].name}\n";

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
        
        private static BaseNotation InitNotation(NotationType type, string value)
        {
            switch (type)
            {
                case NotationType.Infix:
                    return new Infix(value);
                case NotationType.Prefix:
                    return new Prefix(value);
                case NotationType.Postfix:
                    return new Postfix(value);
                default:
                    throw new Exception("Invalid notation type.");
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