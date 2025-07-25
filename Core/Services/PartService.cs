namespace BoschTraceabilityAPI.Core.Services;
using BoschTraceabilityAPI.Domain.Entities;
using BoschTraceabilityAPI.Infrastructure;
using BoschTraceabilityAPI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PartService : IPartService
{
    private readonly AppDbContext _context;
    public PartService(AppDbContext context) => _context = context;

    public async Task<Part> CreateAsync(Part part)
    {
        _context.Parts.Add(part);
        await _context.SaveChangesAsync();
        return part;
    }

    public async Task<List<Part>> ListAsync() => await _context.Parts.ToListAsync();

    public async Task<Part?> GetByIdAsync(Guid id) => await _context.Parts.FindAsync(id);
}
