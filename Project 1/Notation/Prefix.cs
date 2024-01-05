using Utils.Stack;

namespace Project_1.Notation
{
    public class Prefix : BaseNotation
    {
        public Prefix(string value) : base(value)
        {
        }

        public override BaseNotation Convert(NotationType to)
        {
            return this;
        }

        public Infix ToInfix()
        {
            var value = Value; // Copy value so we won't call property getter each time
            var length = value.Length;
            var stack = new Stack<string>(length); // Stack for operands

            // Start from end to start cause it's prefix
            // in prefix, the operator shows up before the operands
            // So we first find operands, then the operator
            for (var i = length - 1; i >= 0; i--)
            {
                var token = value[i];

                // If token was operand, add it to stack
                // otherwise, pop two operands and add them to stack with operator
                stack.Push(
                    Utils.Utils.IsAlphaNum(token)
                        ? token.ToString()
                        : $"({stack.Pop()} {token} {stack.Pop()})"
                );
            }

            return new Infix(stack.Pop());
        }
    }
}