using System;
using System.Collections.Generic;
using System.Text;

namespace ht19
{
    internal class Book
    {
        public static int Id { get; set; } = 0;
        public string Title { get; set; } = null!;
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public Category Category { get; set; } = null!;

        public Book(string title, int price, int categoryId)
        {
            Id++;
            Title = title;
            Price = price;
            CategoryId = categoryId;
            IsDeleted = false;
        }
    }
}
