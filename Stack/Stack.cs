using System;
using System.Collections;

namespace Stack
{
    public class Stack<T>  : IEnumerable
    {
        T[] collection;
        int index = 0;
        public int Count 
        { 
            get
            {
                return index;
            }
        }

        public Stack()
        {
            collection = new T[10];
        }

        public void Push(T item)
        {
            if(Count == collection.Length)
            {
                T[] newCollection = new T[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    newCollection[i] = collection[i];
                }

                collection = newCollection;
            }

            collection[index] = item;
            index++;
        }

        public T Pop()
        {
            T item = collection[index - 1];
            collection[index - 1] = default;
            index--;

            return item;
        }

        public T Peek()
        {
            return collection[index - 1];
        }

        public void Clear()
        {
            if (Count == 0)
                collection = new T[10];

            for (int i = 0; i < Count; i++)
            {
                collection[i] = default;
            }

            index = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (collection[i].Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (Count > (array.Length - arrayIndex))
                throw new ArgumentException();

            for (int i = Count - 1; i >= 0; i--)
            {
                array[arrayIndex] = collection[i];
                arrayIndex++;
            }
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            for (int i = Count - 1, j = 0; i >= 0; i--, j++)
            {
                newArray[j] = collection[i];
            }

            return newArray;
        }

        public void TrimExcess()
        {
            if (Count == 0)
                collection = new T[10];
            else
            {
                if (Count / (collection.Length % 100) < 90)
                {
                    T[] newCollection = new T[Count];
                    for (int i = 0; i < Count; i++)
                    {
                        newCollection[i] = collection[i];
                    }
                    collection = newCollection;
                }
            }
        }

        public bool TryPeek(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = this.Peek();
                return true;
            }
        }

        public bool TryPop(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = this.Pop();
                return true;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator
        {
            Stack<T> _stack;
            T value;
            int i = 0;

            public object Current
            {
                get
                {
                    return value;
                }
            }

            public Enumerator(Stack<T> stack)
            {
                _stack = stack;
                i = stack.Count - 1;
            }

            public bool MoveNext()
            {
                if (_stack.Count == 0)
                    return false;

                if (i >= 0)
                {
                    value = _stack.collection[i];
                    i--;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _stack = null;
            }
        }
    }
}
