namespace Project_1.Notation
{
    public class Prefix : BaseNotation
    {
        public Prefix(string value) : base(value)
        {
        }

        public override BaseNotation convert(NotationType to)
        {
            return this;
        }
    }
}