using System;
using Project_2.LinkList;

namespace Project_2.GenList
{
    public class GeneralizedList<TType>
    {
        private readonly GenNode<TType> _head;
        private GenNode<TType> _last;

        public GeneralizedList()
        {
            var node = new GenNode<TType>(NodeType.Atomic, default); // Create a dummy genNode
            node.Link = node;
            _head = node;
            _last = node;
        }

        public GenNode<TType> AddNode(GenNode<TType> genNode)
        {
            _last.Link = genNode;
            _last = genNode;
            _last.Link = _head;

            return genNode;
        }

        public GenNode<TType> AddNode(NodeType type, object data, GenNode<TType> link = null)
        {
            var node = new GenNode<TType>(type, data, link);
            return AddNode(node);
        }

        public GenNode<TType> RemoveNode(GenNode<TType> genNode)
        {
            var last = _head;
            var thisNode = _head.Link;
            while (thisNode != _head)
            {
                if (thisNode == genNode)
                {
                    last.Link = thisNode.Link; // Remove thisNode from the list

                    if (thisNode == _last) // if this genNode is the last genNode
                        _last = last; // Update the last genNode

                    return thisNode; // GenNode deleted. we're done.
                }

                last = thisNode;
                thisNode = thisNode.Link;
            }

            return null;
        }

        public void Print(GenNode<TType> genNode = null, bool endl = true)
        {
            if (genNode == null)
                genNode = _head.Link;

            Console.Write("<");
            while (genNode != _head)
            {
                if (genNode.Type == NodeType.Atomic)
                    Console.Write(genNode.Data);
                else
                    genNode.DLink.Print(endl: false);

                if (genNode.Link != null && genNode.Link != _head) Console.Write(", ");
                genNode = genNode.Link;
            }

            Console.Write(">");

            if (endl) Console.WriteLine();
        }

        public int Depth(GenNode<TType> genNode = null)
        {
            if (genNode == null)
                genNode = _head.Link;

            var max = 0;
            while (genNode != _head)
            {
                if (genNode.Type == NodeType.SubList)
                {
                    var n = genNode.DLink.Depth();
                    if (max < n)
                        max = n;
                }

                genNode = genNode.Link;
            }

            return max + 1;
        }

        public int Sum(GenNode<TType> genNode = null)
        {
            if (typeof(TType) != typeof(int))
                throw new Exception("Type must be int");

            if (genNode == null)
                genNode = _head.Link;

            var sum = 0;
            while (genNode != _head)
            {
                if (genNode.Type == NodeType.SubList)
                    sum += genNode.DLink.Sum();
                else
                    sum += Convert.ToInt32(genNode.Data);

                genNode = genNode.Link;
            }

            return sum;
        }

        public void DeleteNodeByData(TType data)
        {
            var node = _head.Link;

            while (node != _head)
            {
                if (node.Type == NodeType.Atomic && node.Data.Equals(data))
                    RemoveNode(node);
                else if (node.Type == NodeType.SubList)
                    node.DLink.DeleteNodeByData(data);

                node = node.Link;
            }
        }

        public int Length()
        {
            var length = 0;
            var p = _head.Link;

            while (p != _head)
            {
                if (p.Type == NodeType.Atomic)
                    length++;
                else if (p.Type == NodeType.SubList)
                    length += p.DLink.Length();

                p = p.Link;
            }

            return length;
        }

        public TType[] FetchAllNodes()
        {
            var array = new TType[Length()];
            var index = 0;
            var p = _head.Link;

            while (p != _head)
            {
                if (p.Type == NodeType.Atomic)
                    array[index++] = p.Data;
                else if (p.Type == NodeType.SubList)
                    // p.DLink.FetchAllNodes().CopyTo(array, index);
                    foreach (var data in p.DLink.FetchAllNodes())
                        array[index++] = data;

                p = p.Link;
            }

            return array;
        }

        public CircularLinkList<int> SortedNodes()
        {
            if (typeof(TType) != typeof(int))
                throw new Exception("Type must be int");

            // Add them to integer array
            var length = Length();
            var array = new int[length];
            var index = 0;
            foreach (var item in FetchAllNodes()) array[index++] = Convert.ToInt32(item);

            // Sort data
            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                    if (array[i] > array[j])
                        (array[i], array[j]) = (array[j], array[i]);
            }


            // Add Data To List
            var list = new CircularLinkList<int>();
            foreach (var item in array) list.AddNode(item);

            return list;
        }
    }
}