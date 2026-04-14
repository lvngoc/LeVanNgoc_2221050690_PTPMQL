namespace FirstWebMVC.Models.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }   // THÊM DÒNG NÀY

        public string StudentCode { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string FacultyName { get; set; } = "";
    }
}