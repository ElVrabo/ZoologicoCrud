namespace ZoologicoCrud.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Gender { get; set; }

        public string FotoUrl { get; set; }

        //Un animal esta asociado a una especie
        public int ?SpecieId { get; set; }

        public int ?HabitadId { get; set; }

        public int ?CarerId { get; set; }
        public Specie ?Specie { get; set; }

        public Habitad ?Habitad { get; set; }

        public Carer ?Carer { get; set; }
    }
}
