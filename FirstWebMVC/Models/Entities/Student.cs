using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Code không được để trống")]
        public string StudentCode { get; set; } = "";

        [Required(ErrorMessage = "Full Name không được để trống")]
        public string FullName { get; set; } = "";
    }
}