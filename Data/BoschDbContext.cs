// BoschDbContext.cs
using Microsoft.EntityFrameworkCore;
using MyApi.Entities; // ou o caminho correto para sua classe Part

namespace MyApi.Data
{
    public class BoschDbContext : DbContext
    {
        public BoschDbContext(DbContextOptions<BoschDbContext> options)
            : base(options)
        {
        }

        public DbSet<Part> Parts { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Moviment> Moviments { get; set; }
    }
}
