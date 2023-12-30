using Utils.Stack;

namespace Project_1.Notation
{
    public class Infix : BaseNotation
    {
        public Infix(string value) : base(value)
        {
        }

        public override BaseNotation convert(NotationType to)
        {
            return this;
        }

        public Prefix ToPrefix()
        {
            var output = "";
            var stack = new Stack<char>(value.Length);

            // Check each character
            foreach (var token in value)
                // If char is alphanum (operand)
                if (Utils.Utils.IsAlphaNum(token))
                {
                    output += token;
                }
                else if (token == '(')
                {
                    stack.Push(token);
                }
                else if (token == ')')
                {
                    char p;
                    while (!stack.IsEmpty() && (p = stack.Pop()) != '(')
                        output += p;
                }
                // Char is operator
                else
                {
                    // Pops ops with higher priority from stack and add them to output
                    while (
                        !stack.IsEmpty() && stack.TopItem() != '(' &&
                        GetPriority(token) >= GetPriority(stack.TopItem())
                    )
                        output += stack.Pop();

                    stack.Push(token);
                }

            while (!stack.IsEmpty())
                output += stack.Pop();

            return new Prefix(output);
        }
    }
}