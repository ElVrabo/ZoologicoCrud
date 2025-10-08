using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class SpecieReadDto
    {
        public int Id { get; set; }
        [Display(Name ="Tipo de especie")]
        public string Name { get; set; }

    }
}
