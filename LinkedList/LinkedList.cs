using System;
using System.Collections;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable
    {
        int count;
        public LinkedListNode<T> first;
        public LinkedListNode<T> last;

        public int Count
        {
            get
            {
                return count;
            }
        }
        public LinkedListNode<T> First
        {
            get
            {
                return first;
            }
        }
        public LinkedListNode<T> Last
        {
            get
            {
                return last;
            }
        }

        public LinkedList()
        {
            first = null;
            last = null;
            count = 0;
        }

        public LinkedList(IEnumerable collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            int i = 0;
            foreach (T value in collection)
            {
                if (i == 0)
                {
                    AddFirst(value);
                    i++;
                }
                else
                    AddLast(value);
            }
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            newNode.next = First;
            newNode.previous = null;
            newNode.list = this;


            if (First != null)
                First.previous = newNode;
            if (Last == null)
                last = newNode;

            first = newNode;
            count++;
            return newNode;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != null)
                throw new InvalidOperationException();

            node.next = First;
            node.previous = null;
            node.list = this;

            if (First != null)
                First.previous = node;
            if (Last == null)
                last = node;

            first = node;
            count++;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            newNode.next = null;
            newNode.list = this;

            if (First == null)
                first = newNode;
            if (Last != null)
            {
                newNode.previous = Last;
                Last.next = newNode;
            }

            last = newNode;
            count++;

            return newNode;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != null)
                throw new InvalidOperationException();

            node.next = null;
            node.list = this;

            if (First == null)
                first = node;
            if (Last != null)
            {
                node.previous = Last;
                Last.next = node;
            }

            last = node;
            count++;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
                throw new ArgumentNullException();
            if (node.List != this || newNode.List != null)
                throw new InvalidOperationException();

            newNode.next = node.Next;

            if (node.Next != null)
                node.next.previous = newNode;
            else
                last = newNode;

            node.next = newNode;
            newNode.previous = node;
            newNode.list = this;
            count++;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this)
                throw new InvalidOperationException();

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            AddAfter(node, newNode);

            return newNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
                throw new ArgumentNullException();
            if (node.List != this || newNode.List != null)
                throw new InvalidOperationException();

            newNode.next = node;
            newNode.previous = node.Previous;
            newNode.list = this;

            if (node.Previous != null)
                node.previous.next = newNode;
            else
                first = newNode;

            node.previous = newNode;
            count++;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this)
                throw new InvalidOperationException();

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);

            AddBefore(node, newNode);

            return newNode;
        }

        public void Clear()
        {
            LinkedListNode<T> node = null;

            while (First != null)
            {
                if (count > 1)
                {
                    First.next.previous = null;
                    node = First;
                    node.list = null;
                    first = First.Next;
                    node.next = null;
                }
                else
                {
                    First.list = null;
                    first = null;
                    last = null;
                }
                count--;
            }
        }

        public bool Contains(T value)
        {
            LinkedListNode<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(value))
                    return true;
                node = node.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            if (Count > (array.Length - index))
                throw new ArgumentException();

            LinkedListNode<T> node = First;

            for (int i = 0, j = index; i < Count && j < array.Length; i++, j++)
            {
                array[j] = node.Value;
                node = node.Next;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(value))
                    return node;
                node = node.Next;
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> node = Last;

            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(value))
                    return node;
                node = node.Previous;
            }

            return null;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this)
                throw new InvalidOperationException();

            if (node.Previous != null)
                node.previous.next = node.Next;
            else
                first = node.Next;

            if (node.Next != null)
                node.next.previous = node.Previous;
            else
                last = node.Previous;

            node.next = null;
            node.previous = null;
            node.list = null;
            count--;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                if (node.Value.Equals(value))
                {
                    Remove(node);
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            Remove(First);
        }

        public void RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            Remove(Last);
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator
        {
            LinkedListNode<T> node;
            T value;

            public object Current
            {
                get
                {
                    return value;
                }
            }

            public Enumerator(LinkedList<T> linkedList)
            {
                node = linkedList.First;
            }

            public bool MoveNext()
            {
                if (node == null)
                    return false;

                value = node.Value;
                node = node.Next;
                return true;
            }

            public void Reset()
            {
                node = null;
            }
        }
    }
}
