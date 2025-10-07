using Microsoft.AspNetCore.Mvc;

namespace ZoologicoCrud.Controllers
{
    public class SpecieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
