namespace Project_1.Notation
{
    public class Postfix : BaseNotation
    {
        public Postfix(string value) : base(value)
        {
        }

        public override BaseNotation convert(NotationType to)
        {
            return this;
        }
    }
}