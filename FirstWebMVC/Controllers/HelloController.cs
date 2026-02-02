using Microsoft.AspNetCore.Mvc;

namespace FirstWebMVC.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Xinchao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Xinchao(string fullName)
        {
            ViewBag.Name = "Xin chào: " + fullName;
            return View();
        }
    }
}