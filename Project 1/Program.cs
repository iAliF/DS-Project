using System;
using Project_1.Notation;

namespace Project_1
{
    internal static class Program
    {
        // List of ValueTuples
        // Tuple => Name, From, To
        private static readonly (string name, NotationType from, NotationType to)[] Options =
        {
            ("Infix to Prefix", NotationType.Infix, NotationType.Prefix),
            ("Infix to Postfix", NotationType.Infix, NotationType.Postfix),
            ("Prefix to Infix", NotationType.Prefix, NotationType.Infix),
            ("Prefix to Postfix", NotationType.Prefix, NotationType.Postfix),
            ("Postfix to Infix", NotationType.Postfix, NotationType.Infix),
            ("Postfix to Prefix", NotationType.Postfix, NotationType.Prefix)
        };

        private static string GetHelpText()
        {
            var output = "";
            int i;
            for (i = 0; i < Options.Length; i++)
                output += $"{i + 1}. {Options[i].name}\n";

            output += $"{++i}. Auto Convert\n"; // Exit option
            output += $"{++i}. Exit\n"; // Exit option
            return output;
        }

        private static int GetOption()
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var option) && option >= 1 && option <= 8)
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

        private static string GetExpression()
        {
            Console.Write("Enter expression: ");

            string exp;
            while ((exp = Console.ReadLine()?.Trim())?.Length == 0)
                Console.Write("Enter expression: ");

            return exp;
        }

        private static void GetKey(bool exit = false)
        {
            var to = exit ? "exit" : "continue";
            Console.WriteLine($"Press any key to {to} ...");
            Console.ReadKey();
        }

        public static void Main()
        {
            var helpText = GetHelpText();
            Console.WriteLine(helpText);

            int option;
            while ((option = GetOption()) != 8)
            {
                var exp = GetExpression();

                try
                {
                    // Auto Convert
                    if (option == 7)
                    {
                        NotationType from;
                        if (Utils.Utils.IsOperator(exp[0]))
                            from = NotationType.Prefix;
                        else if (Utils.Utils.IsOperator(exp[exp.Length - 1]))
                            from = NotationType.Postfix;
                        else
                            from = NotationType.Infix;

                        Console.WriteLine($"From: {from}");
                        var to = new[] { NotationType.Infix, NotationType.Prefix, NotationType.Postfix };
                        foreach (var type in to)
                            if (type != from)
                                Console.WriteLine($"{type}: {InitNotation(from, exp).Convert(type).Value}");
                    }
                    else
                    {
                        // Other Conversions
                        var data = Options[option - 1]; // Get converting data 
                        var result = InitNotation(data.from, exp).Convert(data.to);
                        Console.WriteLine($"Result: {result.Value}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input.");
                }

                GetKey();
                Console.WriteLine($"\n{helpText}"); // Show help text again
            }

            GetKey(true);
        }
    }
}