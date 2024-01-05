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
    }
}