namespace Project_2.LinkList
{
    public class LinkNode<TType>
    {
        public TType Data;
        public LinkNode<TType> RLink; // Right link
        public LinkNode<TType> LLink; // Left link
    }
}