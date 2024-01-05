using System.Collections.Generic;

namespace Project_1.Notation
{
    public abstract class BaseNotation
    {
        private readonly Dictionary<char, int> _priority = new Dictionary<char, int>
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
            { '>', 5 }
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

        public string Value => _value;

        protected BaseNotation(string value)
        {
            _value = value.Replace(" ", "");
        }

        public abstract BaseNotation Convert(NotationType to);

        public int GetPriority(char c)
        {
            return _priority.ContainsKey(c) ? _priority[c] : 10;
        }

        public override string ToString()
        {
            return $"{GetType().Name}({_value})";
        }
    }
}