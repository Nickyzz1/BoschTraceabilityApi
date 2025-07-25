namespace BoschTraceabilityAPI.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using BoschTraceabilityAPI.Domain.Entities;

public interface IPartService
{
    Task<Part> CreateAsync(Part part);
    Task<List<Part>> ListAsync();
    Task<Part?> GetByIdAsync(Guid id);
}
