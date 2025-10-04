namespace ZoologicoCrud.Models
{
    public class Habitad
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Una habitad tiene muchos animales
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
