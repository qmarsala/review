using System.Collections.Generic;

namespace src
{
    public class HashTable<T>
    {
        public int Count { get; private set; } = 0;

        private Dictionary<int, T> Storage = new Dictionary<int, T>();

        public void Add(T item)
        {
            var key = item.GetHashCode();
            Storage[key] = item;
            Count++;
        }

        public void Remove(T item)
        {
            var key = item.GetHashCode();
            Storage.Remove(key);
            Count--;
        }

        public bool Contains(T item)
        {
            try 
            {
                var key = item.GetHashCode();
                return Storage[key] != null;
            }
            catch(KeyNotFoundException)
            {
                return false;
            }
        }
    }
}