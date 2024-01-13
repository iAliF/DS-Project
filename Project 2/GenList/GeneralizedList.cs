using System;

namespace Project_2.GenList
{
    public class GeneralizedList<TType>
    {
        private readonly Node<TType> _head;
        private Node<TType> _last;

        public GeneralizedList()
        {
            var node = new Node<TType>(NodeType.Atomic, default); // Create a dummy node
            node.Link = node;
            _head = node;
            _last = node;
        }

        public Node<TType> AddNode(Node<TType> node)
        {
            _last.Link = node;
            _last = node;
            _last.Link = _head;

            return node;
        }

        public Node<TType> AddNode(NodeType type, object data, Node<TType> link = null)
        {
            var node = new Node<TType>(type, data, link);
            return AddNode(node);
        }

        public void Print(Node<TType> node = null, bool endl = true)
        {
            if (node == null)
                node = _head.Link;

            Console.Write("<");
            while (node != _head)
            {
                if (node.Type == NodeType.Atomic)
                    Console.Write(node.Data);
                else
                    node.DLink.Print(endl: false);

                if (node.Link != null && node.Link != _head) Console.Write(", ");
                node = node.Link;
            }

            Console.Write(">");

            if (endl) Console.WriteLine();
        }

        public int Depth(Node<TType> node = null)
        {
            if (node == null)
                node = _head.Link;

            var max = 0;
            while (node != _head)
            {
                if (node.Type == NodeType.SubList)
                {
                    var n = node.DLink.Depth();
                    if (max < n)
                        max = n;
                }

                node = node.Link;
            }

            return max + 1;
        }
    }
}