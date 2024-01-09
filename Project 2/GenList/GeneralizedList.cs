namespace Project_2.GenList
{
    public class GeneralizedList<TType>
    {
        private readonly Node<TType> _head = null;
        private Node<TType> _last = null;

        public GeneralizedList()
        {
            var node = new Node<TType>(NodeType.Atomic, default, null); // Create a dummy node
            node.Link = node;
            _head = node;
            _last = node;
        }
    }
}