using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Services.Interfaces;
using ZoologicoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ZoologicoCrud.Services.Implementations
{
    public class AnimalService : IAnimalService
    {
        private readonly AppDbContext _context;

        public AnimalService(AppDbContext context)
        {
            _context = context;
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
                }).FirstOrDefaultAsync();
            if (animal == null)
                Console.WriteLine("El animal con ese id no se encontro");
            return animal;
        }
        public async Task AddAsync(AnimalCreateDto animalCreateDto)
        {
            var animal = new Animal
            {
                Name = animalCreateDto.Name,
                Description = animalCreateDto.Description,
                Gender = animalCreateDto.Gender,
                FotoUrl = animalCreateDto.FotoUrl,
            };
            await _context.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AnimalCreateDto animalCreateDto)
        {
            var animal = await _context.Animals.FindAsync(animalCreateDto.Id);
            if(animal == null)
                Console.WriteLine("El producto no se encontro");

            animal.Name = animalCreateDto.Name;
            animal.Description = animalCreateDto.Description;
            animal.Gender = animalCreateDto.Gender;
            animal.FotoUrl = animalCreateDto.FotoUrl;
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
    }
}
