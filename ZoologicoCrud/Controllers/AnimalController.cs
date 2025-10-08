using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Models;
using ZoologicoCrud.Services.Implementations;
using ZoologicoCrud.Services.Interfaces;

namespace ZoologicoCrud.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ISpecieService _specieService;

        public AnimalController(IAnimalService animalService, ISpecieService specieService)
        {
            _animalService = animalService;
            _specieService = specieService;
        }
        public async Task<IActionResult> Index()
        {
            //Se mapea una entidad a DTO (convertir) para que la vista
            //no trabaje directamente con los modelos de la bd
            var animals = await _animalService.GetAllAsync();
            return View(animals);
        }
        public async Task<IActionResult> Create()
        {
            /*Se crea una lista a traves de las especies creadas*/
            var species = await _specieService.GetAllAsync();
            /*ViewBag es una forma dinamica de pasar datos desde el controlador hacia la vista*/
            /*SelectList es una clase de ASP.NET que sirve para crear una lista desplegable*/
            ViewBag.Species = new SelectList(species, "Id", "Name");
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
        
        public async Task<IActionResult> Edit(int id)
        {
            var species = await _specieService.GetAllAsync();
            ViewBag.Species = new SelectList(species, "Id", "Name");

            AnimalReadDto animalReadDto = await _animalService.GetByIdAsync(id);
            //Se convierte el objeto animalReadDto a otro DTO
            //AnimalCreateDto, esto porque la vista de edicion usa el mismo formulario que la creacion
            var animalCreateDto = animalReadDto.Adapt<AnimalCreateDto>();
            return View(animalCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AnimalCreateDto animalCreateDto)
        {
            await _animalService.UpdateAsync(id, animalCreateDto);
            TempData["SuccessMessage"] = "El animal se actualizo con exito";
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Delete()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Details(int id) {
            var animal = await _animalService.GetByIdAsync(id);
            return View(animal);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _animalService.DeleteAsync(id);
                TempData["SuccessMessage"] = "El animal se borro con exito";
            }
            catch (Exception ex) {
                TempData["ErrorMessage"] = $"Ocurrio un problema{ex}";
            }
            //return View();
            return RedirectToAction("Index");
        }
    }
}
