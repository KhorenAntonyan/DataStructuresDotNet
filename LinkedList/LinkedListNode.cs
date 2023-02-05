namespace LinkedList
{
    public sealed class LinkedListNode<T>
    {
        public LinkedList<T> list = null;
        public LinkedListNode<T> next = null;
        public LinkedListNode<T> previous = null;

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Next { get { return next; } }
        public LinkedListNode<T> Previous { get { return previous; } }
        public T Value { get; set; }

        public LinkedListNode(T value)
        {
            Value = value;
        }

    }
}
