using KODPersonalAccount.Contracts.Directions;
using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Application.Directions;

/// <inheritdoc cref="IDirectionAppService"/>
public class DirectionAppService : 
    IDirectionAppService
{
    private readonly IDirectionRepository _directionRepository;

    public DirectionAppService(IDirectionRepository directionRepository)
    {
        _directionRepository = directionRepository;
    }
    
    /// <inheritdoc/>
    public async Task<Direction?> GetAsync(
        string title)
    {
        return await _directionRepository.GetAsync(
            title);
    }

    /// <inheritdoc/>
    public async Task<Direction> CreateAsync(
        DirectionCreateDto input)
    {
        return await _directionRepository.CreateAsync(
            input.Title,
            input.Description);
    }

    /// <inheritdoc/>
    public async Task<Direction?> UpdateAsync(
        string title,
        DirectionUpdateDto input)
    {
        return await _directionRepository.UpdateAsync(
            title: title, 
            description: input.Description);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        string title)
    {
        await _directionRepository.DeleteAsync(
            title);
    }
}