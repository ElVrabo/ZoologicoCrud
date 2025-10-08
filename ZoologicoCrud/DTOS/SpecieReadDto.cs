using System.ComponentModel.DataAnnotations;
using ZoologicoCrud.Models;

namespace ZoologicoCrud.DTOS
{
    public class SpecieReadDto
    {
        [Display(Name="Numero")]
        public int Id { get; set; }
        [Display(Name ="Nombre de la especie")]
        public string Name { get; set; }

        //public ICollection<Animal> Animals { get; set; }

    }
}
