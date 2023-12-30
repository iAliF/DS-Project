using System;
using System.Linq;


namespace Utils.Stack
{
    public class Stack<TType>
    {
        private const int DefaultMaxSize = 100;
        private readonly TType[] _array;

        private readonly int _maxSize;
        private int _top = -1;

        public Stack() : this(DefaultMaxSize)
        {
        }

        public Stack(int maxSize)
        {
            _maxSize = maxSize;
            _array = new TType[maxSize];
        }

        public int Count => IsEmpty() ? 0 : _top + 1;

        public bool IsEmpty()
        {
            return _top == -1;
        }

        public bool IsFull()
        {
            return _top == _maxSize - 1;
        }

        public void Push(TType item)
        {
            if (IsFull())
                throw new StackOverflowException();

            _array[++_top] = item;
        }

        public TType Pop()
        {
            if (IsEmpty())
                throw new StackEmptyException();

            return _array[_top--];
        }

        public TType TopItem()
        {
            if (IsEmpty())
                throw new StackEmptyException();
            
            return _array[_top];
        }

        public void Clear()
        {
            _top = -1;
        }

        public bool Contains(TType item)
        {
            var index = Array.IndexOf(_array, item);

            return index != -1 && index <= _top;
        }

        public TType[] ToArray()
        {
            return IsEmpty() ? new TType[] { } : _array.Take(Count).ToArray();
        }
    }
}