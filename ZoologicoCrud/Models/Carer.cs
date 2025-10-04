using System.ComponentModel.DataAnnotations.Schema;

namespace ZoologicoCrud.Models
{
    public class Carer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //[Column("isActive")]
        public bool IsActive { get; set; } = true;

        // Un cuiador puede estar a cargo de varios animales
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
