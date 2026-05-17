using System;
using System.Collections.Generic;
using System.Text;

namespace ht19
{
    internal class Category
    {
        public static int Id { get; set; } = 0;
        public string CategoryName { get; set; } = null!;
        public List<Book> Books { get; set; } = new();

        public Category(string categoryName) 
        {
            Id++;
            CategoryName = categoryName;
        }
    }
}
