using Utils.Stack;

namespace Project_1.Notation
{
    public class Postfix : BaseNotation
    {
        public Postfix(string value) : base(value)
        {
        }

        public override BaseNotation Convert(NotationType to)
        {
            return this;
        }

        public Infix ToInfix()
        {
            var stack = new Stack<string>(Value.Length); // Stack for operands

            foreach (var token in Value)
            {
                if (Utils.Utils.IsAlphaNum(token))
                    stack.Push(token.ToString());
                else
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();
                    stack.Push($"({op2} {token} {op1})");
                }
            }

            return new Infix(stack.Pop());
        }

        public Prefix ToPrefix()
        {
            var stack = new Stack<string>(Value.Length); // Stack for operands

            foreach (var token in Value)
            {
                if (Utils.Utils.IsAlphaNum(token))
                    stack.Push(token.ToString());
                else
                {
                    var op1 = stack.Pop();
                    var op2 = stack.Pop();
                    stack.Push($"{token}{op2}{op1}");
                }
            }

            return new Prefix(stack.Pop());
        }
    }
}