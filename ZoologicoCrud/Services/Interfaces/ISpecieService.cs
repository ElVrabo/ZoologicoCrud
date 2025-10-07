using ZoologicoCrud.DTOS;

namespace ZoologicoCrud.Services.Interfaces
{
    public interface ISpecieService
    {
        Task AddAsync(SpecieCreateDto specieCreateDto);
    }
}
