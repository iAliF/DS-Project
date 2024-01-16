using System;

namespace Project_2.LinkList
{
    public class LinkList<TType>
    {
        private LinkNode<TType> _head;
        private LinkNode<TType> _last;

        public LinkList()
        {
            var node = new LinkNode<TType>(default);
            node.RLink = node;
            node.LLink = node;
            _head = node;
            _last = node;
        }

        public void AddNode(LinkNode<TType> node)
        {
            node.RLink = _last.RLink;
            node.LLink = _last;
            _last.RLink = node;
            _last = node;
        }

        public void AddNode(TType data)
        {
            var node = new LinkNode<TType>(data);
            AddNode(node);
        }

        public void Print()
        {
            Console.Write('<');

            var p = _head.RLink;
            while (p != _head)
            {
                Console.Write(p.Data);

                if (p.RLink != _head) Console.Write(", ");
                p = p.RLink;
            }

            Console.WriteLine('>');
        }

        public void InversePrint()
        {
            Console.Write('<');

            var p = _last;
            while (p != _head)
            {
                Console.Write(p.Data);

                if (p.LLink != _head) Console.Write(", ");
                p = p.LLink;
            }

            Console.WriteLine('>');
        }
    }
}