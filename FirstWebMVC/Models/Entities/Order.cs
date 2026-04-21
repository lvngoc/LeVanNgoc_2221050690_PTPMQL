using System.ComponentModel.DataAnnotations;
using FirstWebMVC.Models.Entities;
namespace FirstWebMVC.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        // FK Customer
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // 1 Order - N OrderDetails
        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}