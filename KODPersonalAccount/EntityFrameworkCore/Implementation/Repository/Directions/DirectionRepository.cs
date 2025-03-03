using KODPersonalAccount.Applications.EntityFrameworkCore;
using KODPersonalAccount.Applications.Interfaces.Repository;
using KODPersonalAccount.Applications.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.Applications;

/// <inheritdoc cref="IDirectionRepository"/>
public class DirectionRepository :
    IDirectionRepository
{
    private readonly DataContext _context;

    public DirectionRepository(DataContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc/>
    public async Task<Direction?> GetAsync(
        string title)
    {
        var ditection = await _context.Directions.AsNoTracking().FirstOrDefaultAsync(d => d.Title == title);
        
        return ditection;
    }

    /// <inheritdoc/>
    public async Task<Direction> CreateAsync(
        string title,
        string description)
    {
        var direction = new Direction(
            title,
            description);
        
        await _context.Directions.AddAsync(direction);
        await _context.SaveChangesAsync();
        
        return direction;
    }

    /// <inheritdoc/>
    public async Task<Direction?> UpdateAsync(
        string title,
        string description)
    {
        var direction = await GetAsync(
            title);
        
        if (direction is null)
            return null;
        
        direction.SetDescription(
            description);
        
        _context.Directions.Update(direction);
        await _context.SaveChangesAsync();
        
        return direction;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        string title)
    {
        var direction = await GetAsync(
            title);
        
        if (direction is null)
            return;
        
        _context.Directions.Remove(direction);
        await _context.SaveChangesAsync();
    }
}
