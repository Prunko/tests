using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class StorageUnit<T> where T : class, new()
    {
        public List<T> _items;

        public void AddItem(T item)
        {
            _items.Add(item);
        }

        public T GetItem(int index)
        {
            return _items[index];
        }
    }
}
