using Microsoft.EntityFrameworkCore;
using ZoologicoCrud.Models;

namespace ZoologicoCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }   
        public DbSet<Carer> Carers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet <Feeding> Feedings { get; set; }
        public DbSet <Habitad> Habitads { get; set; }
        public DbSet<Specie> Species { get; set; }

    }
}
