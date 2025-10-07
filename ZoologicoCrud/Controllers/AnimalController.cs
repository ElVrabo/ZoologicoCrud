using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Models;
using ZoologicoCrud.Services.Interfaces;

namespace ZoologicoCrud.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }
        public async Task<IActionResult> Index()
        {
            //Se mapea una entidad a DTO (convertir) para que la vista
            //no trabaje directamente con los modelos de la bd
            var animals = await _animalService.GetAllAsync();
            return View(animals);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnimalCreateDto animalCreateDto){
            try
            {
                await _animalService.AddAsync(animalCreateDto);
                TempData["SuccessMessage"] = "El animal se registró correctamente.";
                return RedirectToAction("Index"); // Redirige a la lista, evita reenvíos
            }
            catch(Exception ex) 
            {
                TempData["ErrorMessage"] = "Ocurrió un error al registrar el animal.";
                return View(animalCreateDto);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AnimalReadDto animalReadDto = await _animalService.GetByIdAsync(id);
            //Se convierte el objeto animalReadDto a otro DTO
            //AnimalCreateDto, esto porque la vista de edicion usa el mismo formulario que la creacion
            var animalCreateDto = animalReadDto.Adapt<AnimalCreateDto>();
            return View(animalCreateDto);
        }
    }
}
