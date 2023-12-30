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
    }
}