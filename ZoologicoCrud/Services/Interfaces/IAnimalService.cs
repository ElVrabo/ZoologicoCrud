using ZoologicoCrud.DTOS;

namespace ZoologicoCrud.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalReadDto>> GetAllAsync();
        Task<AnimalReadDto> GetByIdAsync(int id);
        Task AddAsync(AnimalCreateDto animal);
        Task UpdateAsync(int id,AnimalCreateDto animal);
        Task DeleteAsync(int id);
    }
}
