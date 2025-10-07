using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class AnimalCreateDto
    {
        public int Id { get; set; }
        // se reciben los datos desde el cliente en JSON en este DTO y despues en un controller se convierte a
        //entidad Animal 

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Description { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El genero es requerido")]
        public string Gender { get; set; }

        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "La imagen es requerida")]
        public string FotoUrl { get; set; }

        [Display(Name = "Cuidador")]
        public int CarerId { get; set; }

        [Display(Name = "Especie")]
        public int SpecieId { get; set; }

        [Display(Name = "Habitad")]
        public int HabitadId { get; set; }
    }
}
