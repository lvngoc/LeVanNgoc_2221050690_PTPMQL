using Microsoft.AspNetCore.Mvc;

namespace YourAppName.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello Lê Văn Ngọc - 2221050690";
            return View();
        }
    }
}
