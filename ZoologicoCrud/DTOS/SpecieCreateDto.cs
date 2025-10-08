using System.ComponentModel.DataAnnotations;
using ZoologicoCrud.Constants;

namespace ZoologicoCrud.DTOS
{
    public class SpecieCreateDto
    {
        //[Display(Name="")]
        [Required(ErrorMessage =Fields.Specie.NameRequired)]
        public string Name { get; set; }
    }
}
