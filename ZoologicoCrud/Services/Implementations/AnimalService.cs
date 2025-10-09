using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Models;
using ZoologicoCrud.Services.Interfaces;
using ZoologicoCrud.Settings;

namespace ZoologicoCrud.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UploadSettings _uploadSettings;
        private readonly ZoologicoSettings _zoologicoSettings;

        public AnimalService(AppDbContext context, IWebHostEnvironment env, IOptions<UploadSettings> uploadSettings, IOptions<ZoologicoSettings> zoologicoSettings)
        {
            _context = context;
            _env = env;
            _uploadSettings = uploadSettings.Value;
            _zoologicoSettings = zoologicoSettings.Value;
        }
        public async Task<IEnumerable<AnimalReadDto>> GetAllAsync()
        {
            //Se mapea una entidad a DTO (convertir) para que la vista
            //no trabaje directamente con los modelos de la bd
            var animals = await _context.Animals
                .Select(a => new AnimalReadDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Gender = a.Gender,
                    FotoUrl = a.FotoUrl,
                    Specie = a.Specie.Name
                }).ToListAsync();
            return animals;

        }
        public async Task<AnimalReadDto> GetByIdAsync(int id)
        {
            var animal = await _context.Animals
                .Where(a => a.Id == id)
                .Select(a => new AnimalReadDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Gender = a.Gender,
                    FotoUrl = a.FotoUrl,
                    Specie = a.Specie.Name
                    
                }).FirstOrDefaultAsync();
            if (animal == null)
                Console.WriteLine("El animal con ese id no se encontro");
            return animal;
        }
        public async Task AddAsync(AnimalCreateDto animalCreateDto)
        {
            int totalAnimals = _context.Animals.Count();
            if(totalAnimals >= _zoologicoSettings.MaxAnimals)
            {
                 throw new ApplicationException($"No se pueden registrar más de {_zoologicoSettings.MaxAnimals} animales en el zoológico.");
                
            }
            var file = await UploadImage(animalCreateDto.File);
            var animal = new Animal
            {
                Name = animalCreateDto.Name,
                Description = animalCreateDto.Description,
                Gender = animalCreateDto.Gender,
                FotoUrl = file,
                SpecieId = animalCreateDto.SpecieId
            };
            await _context.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AnimalCreateDto animalCreateDto)
        {
            var file = await UploadImage(animalCreateDto.File);
            var animal = await _context.Animals.FindAsync(animalCreateDto.Id);
            if(animal == null)
                Console.WriteLine("El producto no se encontro");

            animal.Name = animalCreateDto.Name;
            animal.Description = animalCreateDto.Description;
            animal.Gender = animalCreateDto.Gender;
            animal.FotoUrl = file;
            animal.SpecieId = animalCreateDto.SpecieId;
            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
                    
            

        }
        public async Task DeleteAsync(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
                Console.WriteLine("No se encontro al animal para eliminar");
             _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

        }

        private async Task<string> UploadImage(IFormFile file)
        {
            ValidateFile(file);

            //string _customPath = Path.Combine(Directory.GetCurrentDirectory(), _uploadSettings.UploadDirectory);
            string _customPath = Path.Combine(_env.WebRootPath, _uploadSettings.UploadDirectory);

            if (!Directory.Exists(_customPath))   // Crear el directorio si no existe
            {
                Directory.CreateDirectory(_customPath);
            }

            // Generar el nombre único del archivo
            var fileName = Path.GetFileNameWithoutExtension(file.FileName)
                            + Guid.NewGuid().ToString()
                            + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_customPath, fileName);

            // Guardar el archivo
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retornar la ruta relativa o completa, según sea necesario
            return $"/{_uploadSettings.UploadDirectory}/{fileName}";
        }
        private void ValidateFile(IFormFile file)
        {
            var permittedExtensions = _uploadSettings.AllowedExtensions.Split(',');
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!permittedExtensions.Contains(extension))
            {
                
                throw new NotSupportedException("El tipo del archivo no es soportado");
            }
        }
    }
}
