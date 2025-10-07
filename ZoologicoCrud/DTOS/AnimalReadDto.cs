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
        [Display(Name="Imagen")]
        public string FotoUrl { get; set; }

        public int SpecieId { get; set; }
        public int HabitadId { get; set; }
        public int CarerId { get; set; }

        public string Specie { get; set; }
        public string Habitad { get; set; }
        public string Carer { get; set; }   
    }
}
