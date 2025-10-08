using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Services.Interfaces;

namespace ZoologicoCrud.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ISpecieService _specieService;

        public SpecieController(ISpecieService specieService) {
          _specieService = specieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpecieCreateDto specieCreateDto)
        {
            await _specieService.AddAsync(specieCreateDto);
            TempData["SuccessAlert"] = "La especie se agrego exitosamente";
            return RedirectToAction("Index");

        }
    }
}
