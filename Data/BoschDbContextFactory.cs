using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyApi.Data;
using Npgsql;

namespace MyApi.Data
{
    public class BoschDbContextFactory : IDesignTimeDbContextFactory<BoschDbContext>
    {
        public BoschDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BoschDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=boschDb;Trusted_Connection=True;TrustServerCertificate=True;");

            // optionsBuilder.UseSqlite("Data Source=BoschDb.db");
            // optionsBuilder.UseNpgsql("Host=localhost;Database=boschDb;Username=root;Password=root");


            return new BoschDbContext(optionsBuilder.Options);
        }
    }
}
