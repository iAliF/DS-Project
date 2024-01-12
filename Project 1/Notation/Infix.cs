using Utils.Stack;

namespace Project_1.Notation
{
    public class Infix : BaseNotation
    {
        public Infix(string value) : base(value)
        {
        }

        public override BaseNotation Convert(NotationType to)
        {
            switch (to)
            {
                case NotationType.Postfix:
                    return ToPostFix();
                case NotationType.Prefix:
                    return ToPrefix();
                case NotationType.Infix:
                default:
                    return this;
            }
        }

        public Postfix ToPostFix()
        {
            var output = "";
            var stack = new Stack<char>(Value.Length);

            // Check each character
            foreach (var token in Value)
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

            return new Postfix(output);
        }

        public Prefix ToPrefix()
        {
            var length = Value.Length;
            var operands = new Stack<string>(length);
            var operators = new Stack<char>(length);

            foreach (var token in Value)
                if (token == '(')
                {
                    operators.Push(token);
                }
                else if (token == ')')
                {
                    char op;
                    while (!operators.IsEmpty() && (op = operators.Pop()) != '(')
                    {
                        var opr1 = operands.Pop();
                        var opr2 = operands.Pop();
                        operands.Push(op + opr2 + opr1);
                    }
                }
                else if (Utils.Utils.IsAlphaNum(token))
                {
                    operands.Push(token.ToString());
                }
                else
                {
                    if (!operators.IsEmpty() &&
                        operators.TopItem() != '(' && GetPriority(token) >= GetPriority(operators.TopItem())
                       )
                        Add();

                    operators.Push(token);
                }

            while (!operators.IsEmpty())
                Add();

            return new Prefix(operands.Pop());

            // Prevent Duplicate Coding
            void Add()
            {
                var op = operators.Pop();
                var opr1 = operands.Pop();
                var opr2 = operands.Pop();
                operands.Push(op + opr2 + opr1);
            }
        }
    }
}