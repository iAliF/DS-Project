using System;

namespace Utils.Stack
{
    [Serializable]
    public class StackEmptyException : Exception
    {
        public StackEmptyException() : base("Stack is empty")
        {
        }
    }
}