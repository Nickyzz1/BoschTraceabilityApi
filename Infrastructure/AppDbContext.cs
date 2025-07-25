namespace BoschTraceabilityAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BoschTraceabilityAPI.Domain.Entities;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Part> Parts => Set<Part>();
    // public DbSet<Station> Stations => Set<Station>();
    // public DbSet<Moviment> Moving => Set<Moviment>();
}
