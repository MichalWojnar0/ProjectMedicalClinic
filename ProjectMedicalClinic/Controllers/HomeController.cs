using Microsoft.AspNetCore.Mvc;

namespace ProjectMedicalClinic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
