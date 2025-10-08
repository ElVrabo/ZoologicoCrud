using Mapster;
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
        public async Task <IActionResult> Index()
        {
            var species = await _specieService.GetAllAsync();
            return View(species);
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
            TempData["SuccessMessage"] = "La especie se agrego exitosamente";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            /*Esto se hace para cargar los datos actuales del objeto a editar*/
            SpecieReadDto specieReadDto = await _specieService.GetByIdAsync(id);
            var specieCreateDto = specieReadDto.Adapt<SpecieCreateDto>();
            return View(specieCreateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, SpecieCreateDto specieCreateDto)
        {
            await _specieService.UpdateAsync(id, specieCreateDto);
            TempData["SuccessMessage"] = "La especie se actualizo con exito";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _specieService.DeleteAsync(id);
                TempData["SuccessMessage"] = "La especie se elimino con exito";
                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                TempData["ErrorMessage"] = $"{ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
