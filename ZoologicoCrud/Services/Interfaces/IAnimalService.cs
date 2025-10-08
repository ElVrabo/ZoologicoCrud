using ZoologicoCrud.DTOS;

namespace ZoologicoCrud.Services.Interfaces
{
    public interface IAnimalService :IGenericService<AnimalReadDto,AnimalCreateDto,AnimalCreateDto>
    {
    }
}
