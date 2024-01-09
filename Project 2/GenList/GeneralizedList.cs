namespace Project_2.GenList
{
    public class GeneralizedList<TType>
    {
        private readonly Node<TType> _head;
        private Node<TType> _last;

        public GeneralizedList()
        {
            var node = new Node<TType>(NodeType.Atomic, default, null); // Create a dummy node
            node.Link = node;
            _head = node;
            _last = node;
        }

        public void AddNode(Node<TType> node)
        {
            _last.Link = node;
            _last = node;
            _last.Link = _head;
        }

        public void AddNode(NodeType type, object data, Node<TType> link)
        {
            var node = new Node<TType>(type, data, link);
            AddNode(node);
        }
    }
}