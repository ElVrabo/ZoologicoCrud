using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;

namespace ZoologicoCrud.Controllers
{
    public class AnimalController : Controller
    {
        private AppDbContext _context;

        public AnimalController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //Se mapea una entidad a DTO (convertir) para que la vista
            //no trabaje directamente con los modelos de la bd
            var animals = _context.Animals
                .Select(a => new AnimalReadDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Gender = a.Gender,
                }).ToList();
            return View(animals);
        }
    }
}
