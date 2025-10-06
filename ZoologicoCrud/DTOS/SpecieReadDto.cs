using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class SpecieReadDto
    {
        [Display(Name ="Tipo de especie")]
        public string Name { get; set; }

    }
}
