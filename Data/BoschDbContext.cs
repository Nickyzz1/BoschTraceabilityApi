using Microsoft.EntityFrameworkCore;
using MyApi.Entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding de estações
            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, Title = "Estação Inicial", Sort = 1 },
                new Station { Id = 2, Title = "Montagem", Sort = 2 },
                new Station { Id = 3, Title = "Inspeção", Sort = 3 }
            );

            base.OnModelCreating(modelBuilder);

            // delete em cascata
            modelBuilder.Entity<Part>()
            .HasOne(p => p.CurStation)
            .WithMany(s => s.Parts)
            .HasForeignKey(p => p.CurStationId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
