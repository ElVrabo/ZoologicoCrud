namespace ZoologicoCrud.Models
{
    public class Feeding
    {
        public int Id { get; set; }
        public string FeedType { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
