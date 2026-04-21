using System.ComponentModel.DataAnnotations;
using FirstWebMVC.Models.Entities;
namespace FirstWebMVC.Models.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        // FK Order
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        // FK Product
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        // Số lượng
        [Range(1, 1000)]
        public int Quantity { get; set; }

        // Giá tại thời điểm mua
        public decimal Price { get; set; }
    }
}