// Repository Clasas filee
// Implements the ISternritterRepository interface

using Microsoft.EntityFrameworkCore;
using Wandenreich.Api.Data;
using Wandenreich.Api.Models;

namespace Wandenreich.Api.Repositories;

public class SternritterRepository : ISternritterRepository
{
    private readonly WandenreichDbContext _context;

    public SternritterRepository(WandenreichDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sternritter>> GetAllAsync()
    {
        return await _context.Sternritters.AsNoTracking().ToListAsync();
    }

    public async Task<Sternritter?> GetByIdAsync(int id)
    {
        return await _context.Sternritters.FindAsync(id);
    }

    public async Task<Sternritter> CreateAsync(Sternritter sternritter)
    {
        _context.Sternritters.Add(sternritter);
        await _context.SaveChangesAsync();
        return sternritter;
    }

    public async Task UpdateAsync(Sternritter sternritter)
    {
        _context.Entry(sternritter).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Sternritter sternritter)
    {
        _context.Sternritters.Remove(sternritter);
        await _context.SaveChangesAsync();
    }
}