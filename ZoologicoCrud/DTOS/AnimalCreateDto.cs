using System.ComponentModel.DataAnnotations;
using ZoologicoCrud.Constants;

namespace ZoologicoCrud.DTOS
{
    public class AnimalCreateDto
    {
        public int Id { get; set; }
        // se reciben los datos desde el cliente en JSON en este DTO y despues en un controller se convierte a
        //entidad Animal 

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = Fields.Animal.NameRequired)]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = Fields.Animal.DescriptionRequired)]
        public string Description { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = Fields.Animal.GenderRequired)]
        [RegularExpression("Macho|Hembra", ErrorMessage = "El genero debe ser Macho o Hembra")]
        public string Gender { get; set; }

        [Display(Name = "Imagen")]
        [Required(ErrorMessage = Fields.Animal.ImageRequired)]
        public IFormFile File { get; set; }

        [Display(Name = "Cuidador")]
        public int CarerId { get; set; }

        [Display(Name = "Especie")]
        [Required(ErrorMessage = Fields.Animal.SpecieRequired)]
        public int SpecieId { get; set; }

        [Display(Name = "Habitad")]
        public int HabitadId { get; set; }
    }
}
