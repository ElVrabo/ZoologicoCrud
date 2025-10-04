using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class AnimalReadDto
    {
        public int Id { get; set; }

        [Display(Name="Animal")]
        public string Name { get; set; }

        [Display(Name="Descripcion")]

        public string Description { get; set; }

        [Display(Name="Genero")]
        public string Gender { get; set; }
    }
}
