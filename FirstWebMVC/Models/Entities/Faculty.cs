namespace FirstWebMVC.Models.Entities
{
    public class Faculty
    {
        public int Id { get; set; }

        public string FacultyName { get; set; } = string.Empty;

        // 1 khoa có nhiều sinh viên
        public List<Student> Students { get; set; } = new();
    }
}