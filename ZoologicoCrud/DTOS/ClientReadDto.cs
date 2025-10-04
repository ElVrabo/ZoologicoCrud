using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class ClientReadDto
    {
        [Display(Name="Nombre del cliente")]
        public string Name { get; set; }

        [Display(Name="Apellido del cliente")]
        public string LastName { get; set; }
    }
}
