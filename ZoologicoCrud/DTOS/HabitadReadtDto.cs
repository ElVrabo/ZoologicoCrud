using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class HabitadReadtDto
    {
        [Display(Name ="Tipo de habitad")]
        public string Name { get; set; }
    }
}
