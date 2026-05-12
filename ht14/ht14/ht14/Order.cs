using System.ComponentModel.DataAnnotations;

namespace ht14
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? CustomerEmail { get; set; }
        public string? InternalNote { get; set; }
    }
}
