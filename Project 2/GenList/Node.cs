using System;

namespace Project_2.GenList
{
    public class Node<TType>
    {
        public readonly NodeType Type;
        private readonly object _data; // data: data if node is atomic, dLink if node is sublist
        public Node<TType> Link;

        public Node(NodeType type, object data, Node<TType> link)
        {
            Type = type;
            _data = data;
            Link = link;
        }

        public TType Data
        {
            get
            {
                if (Type != NodeType.Atomic)
                    throw new Exception("Non-atomic node has no data");

                return (TType)_data;
            }
        }

        public GeneralizedList<TType> DLink
        {
            get
            {
                if (Type != NodeType.SubList)
                    throw new Exception("Atomic node has no DLink");

                return (GeneralizedList<TType>)_data;
            }
        }
    }
}