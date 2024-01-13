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
        
        public Node<TType> RemoveNode(Node<TType> node)
        {
            var last = _head;
            var thisNode = _head.Link;
            while (thisNode != _head)
            {
                if (thisNode == node)
                {
                    last.Link = thisNode.Link; // Remove thisNode from the list
                    
                    if (thisNode == _last) // if this node is the last node
                        _last = last; // Update the last node
                    
                    return thisNode; // Node deleted. we're done.
                }

                last = thisNode;
                thisNode = thisNode.Link;
            }

            return null;
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

        public int Sum(Node<TType> node = null)
        {
            if (typeof(TType) != typeof(int))
                throw new Exception("Type must be int");

            if (node == null)
                node = _head.Link;

            var sum = 0;
            while (node != _head)
            {
                if (node.Type == NodeType.SubList)
                    sum += node.DLink.Sum();
                else
                    sum += Convert.ToInt32(node.Data);

                node = node.Link;
            }

            return sum;
        }
    }
}