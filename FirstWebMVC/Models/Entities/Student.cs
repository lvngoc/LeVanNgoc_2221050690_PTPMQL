using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Code không được để trống")]
        [MaxLength(10, ErrorMessage = "Tối đa 10 ký tự")]
        public string StudentCode { get; set; } = "";

        [Required(ErrorMessage = "Full Name không được để trống")]
        [MaxLength(40, ErrorMessage = "Tối đa 40 ký tự")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = "";
    }
}