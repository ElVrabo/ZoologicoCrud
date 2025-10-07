using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Models;

namespace ZoologicoCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
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
                Description ="Feroz",
                Gender ="Hembra"
            }
            };
            return View(animales);
        }
        [HttpGet]
        public IActionResult TableAnimals()
        {
            var animals = _context.Animals.ToList();
            return View(animals);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Privacy(AnimalCreateDto dto )
        {
           
             var animal = new Animal
            {
                 Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Gender = dto.Gender,
                FotoUrl = dto.FotoUrl,
            };
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
