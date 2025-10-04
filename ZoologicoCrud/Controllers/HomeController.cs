using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Models;

namespace ZoologicoCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<AnimalReadDto> animales = new List<AnimalReadDto> {
                new AnimalReadDto
            {
                Id = 1,
                Name = "Leon",
                Description ="Feroz",
                Gender ="Macho"
            },
                new AnimalReadDto
            {
                Id = 2,
                Name = "Tigre",
                Description ="Hambre",
                Gender ="Macho"
            }
            };
            return View(animales);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
