namespace Project_2.GenList
{
    public class Node<TType>
    {
        public readonly NodeType Type;
        private readonly object _data; // data: data if node is atomic, dLink if node is sublist
        public readonly Node<TType> Link;

        public Node(NodeType type, TType data, Node<TType> dLink, Node<TType> link)
        {
            Type = type;
            _data = data;
            Link = link;
        }

        public TType Data => (TType)_data;

        public Node<TType> DLink => (Node<TType>)_data;
    }
}