using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class Warehouse
    {
        private string[] _items = new string[10];

        public string this[int index]
        {
            get => _items[index];
            set
            {
                if (index < _items.Length && index >= 0)
                {
                    _items[index] = value;

                    OnItemChanged?.Invoke(index, value);
                } else
                {
                    Console.WriteLine("This index is out of range");
                }
            }
        }

        public event Action<int, string> OnItemChanged;
    }
}
