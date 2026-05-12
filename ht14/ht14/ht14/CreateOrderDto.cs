using System.ComponentModel.DataAnnotations;

namespace ht14
{
    public class CreateOrderDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 1000)]
        public int? Quantity { get; set; }

        [Range(0, 100000)]
        public decimal? Price { get; set; }

        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}
