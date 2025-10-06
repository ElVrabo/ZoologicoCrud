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
                }).ToListAsync();
            return animals;

        }
        public async Task<AnimalReadDto> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
        public async Task AddAsync(AnimalCreateDto animalCreateDto) {
            var animal = new Animal
            {
                Name = animalCreateDto.Name,
                Description = animalCreateDto.Description,
                Gender = animalCreateDto.Gender,
                FotoUrl = animalCreateDto.FotoUrl,
            };
        }
    }
}
