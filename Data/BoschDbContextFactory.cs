using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyApi.Data;

namespace MyApi.Data
{
    public class BoschDbContextFactory : IDesignTimeDbContextFactory<BoschDbContext>
    {
        public BoschDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BoschDbContext>();
            // optionsBuilder.UseSqlServer("Server=localhost;Database=boschDb;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlite("Data Source=boschDb.db");

            return new BoschDbContext(optionsBuilder.Options);
        }
    }
}
