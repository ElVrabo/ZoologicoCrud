using Microsoft.EntityFrameworkCore;
using ZoologicoCrud.Data;
using ZoologicoCrud.DTOS;
using ZoologicoCrud.Services.Interfaces;
using ZoologicoCrud.Models;

namespace ZoologicoCrud.Services.Implementations
{
    public class SpecieService : ISpecieService
    {
        private readonly AppDbContext _context;

        public SpecieService(AppDbContext context)
        {
            _context = context;
        }
    public async Task<IEnumerable<SpecieReadDto>> GetAllAsync()
        {
            var species = await _context.Species
                .Select(s => new SpecieReadDto
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToListAsync();
            return species;
        }
    public async Task<SpecieReadDto> GetByIdAsync(int id)
        {
            var specie = await _context.Species
                .Where(s => s.Id == id)
                .Select(s => new SpecieReadDto 
                {
                    Id = s.Id,
                    Name = s.Name,
                }).FirstOrDefaultAsync();
            if(specie == null)
            {
                throw new ApplicationException("la especie no se encontro");
            }
            return specie;
        }
    public async Task AddAsync(SpecieCreateDto specieCreateDto) {
            var specie = new Specie
            {
                Name = specieCreateDto.Name,
            };
            await _context.AddAsync(specie);
            await _context.SaveChangesAsync();
        }
    public async Task UpdateAsync(int id, SpecieCreateDto specieCreateDto)
        {
            var specie = await _context.Species.FindAsync(id);
            if(specie == null)
            {
                throw new ApplicationException("la especie a editar no se encuentra");
            }
            specie.Name = specieCreateDto.Name;
            _context.Species.Update(specie);
            await _context.SaveChangesAsync();

        }
    public async Task DeleteAsync(int id)
        {
            var specie = await _context.Species.FindAsync(id);
            if (specie.Animals.Count >=1)
            {
                throw new ApplicationException("No se puede eliminar esta especie ya que existen animales en ella");
            }
            _context.Species.Remove(specie);
            await _context.SaveChangesAsync();
        }
    }
}
