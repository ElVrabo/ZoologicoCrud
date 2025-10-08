namespace ZoologicoCrud.Services.Interfaces
{
    public interface IGenericService<TReadDto,TCreateDto,TUpdateDto>
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<IEnumerable<TReadDto>> GetAllAsync();
        Task<TReadDto> GetByIdAsync(int id);
        Task AddAsync(TCreateDto createDto);
        Task UpdateAsync(int id, TUpdateDto createDto);
        Task DeleteAsync(int id);
    }
}
