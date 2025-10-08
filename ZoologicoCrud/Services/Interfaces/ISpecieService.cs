using ZoologicoCrud.DTOS;

namespace ZoologicoCrud.Services.Interfaces
{
    public interface ISpecieService
    {
        Task<IEnumerable<SpecieReadDto>> GetAllAsync();
        Task AddAsync(SpecieCreateDto specieCreateDto);
    }
}
