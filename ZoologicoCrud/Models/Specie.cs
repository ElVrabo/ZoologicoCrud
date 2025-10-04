namespace ZoologicoCrud.Models
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Una especie contiene muchos animales
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
