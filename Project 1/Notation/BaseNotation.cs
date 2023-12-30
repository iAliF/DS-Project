using System.Collections.Generic;

namespace Project_1.Notation
{
    public abstract class BaseNotation
    {
        public Dictionary<char, int> PRIORITY = new Dictionary<char, int>
        {
            { '(', 0 },
            { '!', 1 },
            { '^', 2 },
            { '*', 3 },
            { '/', 3 },
            { '%', 3 },
            { '+', 4 },
            { '-', 4 },
            { '<', 5 },
            { '>', 5 },
            // { "<=", 5 },
            // { ">=", 5 },
            // { "==", 6 },
            // { "!=", 6 },
            // { "&&", 7 },
            // { "and", 7 },
            // { "||", 8 },
            // { "or", 8 },
        };

        private readonly string _value;

        public string value => value;

        protected BaseNotation(string value)
        {
            _value = value.Replace(" ", "");
        }

        public abstract BaseNotation convert(NotationType to);

        public override string ToString()
        {
            return $"({_value})";
        }
    }
}