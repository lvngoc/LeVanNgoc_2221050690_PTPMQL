using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models.Entities;
namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student std)
        {
            ViewBag.Student =  std.FullName + ", MSSV: " + std.StudentCode;
            return View();
        }
    }
}