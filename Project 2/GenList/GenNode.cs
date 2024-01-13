using System;

namespace Project_2.GenList
{
    public class GenNode<TType>
    {
        private readonly object _data; // data: data if node is atomic, dLink if node is sublist
        public readonly NodeType Type;
        public GenNode<TType> Link;

        public GenNode(NodeType type, object data, GenNode<TType> link = null)
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