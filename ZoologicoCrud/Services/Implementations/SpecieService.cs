using Microsoft.EntityFrameworkCore;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Services.Interfaces;

namespace ZoologicoCrud.Services.Implementations
{
    public class SpecieService : ISpecieService
    {
        private readonly AppDbContext _context;

        public SpecieService(AppDbContext context)
        {
            _context = context;
        }
    public async Task AddAsync(SpecieCreateDto specieCreateDto) {
            var specie = new Specie
            {
                Name = specieCreateDto.Name,
            };
            await _context.AddAsync(specie);
            await _context.SaveChangesAsync();
        }
    }
}
