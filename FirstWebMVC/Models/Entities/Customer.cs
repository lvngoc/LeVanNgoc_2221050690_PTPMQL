using System.ComponentModel.DataAnnotations;
using FirstWebMVC.Models.Entities;
namespace FirstWebMVC.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [MaxLength(40, ErrorMessage = "Tối đa 40 ký tự")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")  ]
        public string Phone { get; set; } = null!;

        // 1 Customer - N Orders
        public List<Order> Orders { get; set; } = new();
    }
}