using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class SpecieCreateDto
    {
        //[Display(Name="")]
        [Required(ErrorMessage ="El nombre de la especie es requerida")]
        public string Name { get; set; }
    }
}
