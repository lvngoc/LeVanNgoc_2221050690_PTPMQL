using System.ComponentModel.DataAnnotations;
using FirstWebMVC.Models.Entities;
namespace FirstWebMVC.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Range(0, 100000000)]
        public decimal Price { get; set; }
       public List<FirstWebMVC.Models.Entities.OrderDetail> OrderDetails { get; set; } = new();
    }
}