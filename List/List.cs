using System;
using System.Collections;

namespace List
{
    class List<T> : IEnumerable
    {
        T[] collection;
        int index = 0;
        public int Capacity
        {
            get
            {
                return collection.Length;
            }
            set
            {
                collection = new T[value];
            }
        }
        public int Count
        {
            get
            {
                return index;
            }
        }
        public T this[int index]
        {
            get
            {
                return collection[index];
            }
            set
            {
                collection[index] = value;
            }
        }

        public List()
        {
            collection = new T[1];
        }

        public List(IEnumerable _collection)
        {
            if (_collection == null)
                throw new ArgumentNullException();

            collection = new T[1];

            foreach (T value in _collection)
            {
                Add(value);
            }
        }

        public void Add(T item)
        {
            if (Count == Capacity)
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

        public void AddRange(System.Collections.Generic.IEnumerable<T> _collection)
        {
            if (_collection == null)
                throw new ArgumentNullException();

            foreach (T value in _collection)
            {
                Add(value);
            }
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

            Array.Copy(collection, 0, array, arrayIndex, Count);
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (index < 0 || arrayIndex < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            if (index >= Count || index > (array.Length - arrayIndex))
                throw new ArgumentException();

            Array.Copy(collection, index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (Count > array.Length)
                throw new ArgumentException();

            Array.Copy(collection, array, Count);
        }

        public List<T> GetRange(int index, int count)
        {
            if (index < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            if ((index + count) > collection.Length)
                throw new ArgumentException();

            List<T> newList = new List<T>();

            for (int i = index, j = 0; j < count; i++, j++)
            {
                newList[j] = collection[i];
            }

            return newList;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (collection[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public int IndexOf(T item, int index)
        {
            if (index > collection.Length || index < 0)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < Count; i++)
            {
                if (collection[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public int IndexOf(T item, int index, int count)
        {
            if (index > collection.Length || index < 0 || count < 0 || (index + count) > collection.Length)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < count; i++)
            {
                if (collection[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            if (Count == Capacity)
            {
                T[] newCollection = new T[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    newCollection[i] = collection[i];
                }

                collection = newCollection;
            }

            if (index == Count)
                this.Add(item);
            else
            {
                T[] newCollection = new T[Count];

                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                    {
                        newCollection[i] = item;
                        continue;
                    }
                    newCollection[i] = collection[i];
                }

                collection = newCollection;
            }
        }

        public int LastIndexOf(T item)
        {
            for (int i = Count; i >= 0; i--)
            {
                if (collection[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public int LastIndexOf(T item, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i >= 0; i--)
            {
                if (collection[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public int LastIndexOf(T item, int index, int count)
        {
            if (index > collection.Length || index < 0 || count < 0 || (index + count) > collection.Length)
                throw new ArgumentOutOfRangeException();

            for (int i = index, j = 0; j < count; i--, j++)
            {
                if (collection[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public bool Remove(T item)
        {
            T[] newCollection = new T[Count];
            bool result = false;

            for (int i = 0, j = 0; i < Count; i++, j++)
            {
                if (collection[i].Equals(item))
                {
                    index--;
                    result = true;
                    i++;
                }
                newCollection[j] = collection[i];
            }

            collection = newCollection;
            return result;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            collection[index] = default;

            for (int i = index; index < Count - 1; index++)
            {
                collection[index] = collection[index + 1];
            }

            collection[Count - 1] = default;
            this.index--;
        }

        public void RemoveRange(int index, int count)
        {
            if (index < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            if ((index + count) > Count)
                throw new ArgumentException();

            for (int i = index + 1, j = 0; j < count; i++, j++)
            {
                collection[index] = collection[i];
                collection[i] = default;
            }

            this.index -= count;
        }

        public void Reverse()
        {
            Array.Reverse(collection, 0, Count);
        }

        public void Reverse(int index, int count)
        {
            if (index < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            if ((index + count) > Count)
                throw new ArgumentException();

            Array.Reverse(collection, index, count);
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            Array.Copy(collection, newArray, Count);

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

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator
        {
            List<T> list;
            T value;
            int i = 0;

            public object Current
            {
                get
                {
                    return value;
                }
            }

            public Enumerator(List<T> linkedList)
            {
                list = linkedList;
            }

            public bool MoveNext()
            {
                if (list.Count == 0)
                    return false;

                if (i < list.Count)
                {
                    value = list[i];
                    i++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                list = null;
            }
        }
    }
}
