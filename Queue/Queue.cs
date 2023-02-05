using System;
using System.Collections;

namespace Queue
{
    public class Queue<T> : IEnumerable
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

        public Queue()
        {
            collection = new T[10];
        }

        public void Enqueue(T item)
        {
            if (Count == collection.Length)
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

        public T Dequeue()
        {
            T item = collection[0];
            collection[0] = default;

            for (int i = 1; i <= index; i++)
            {
                collection[i - 1] = collection[i];
            }

            index--;
            return item;
        }

        public T Peek()
        {
            return collection[0];
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
                {
                    return true;
                }
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

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex] = collection[i];
                arrayIndex++;
            }
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = collection[i];
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

        public bool TryDequeue(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = this.Dequeue();
                return true;
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

        public IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
