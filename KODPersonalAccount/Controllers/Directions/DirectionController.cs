using KODPersonalAccount.Contracts.Directions;
using KODPersonalAccount.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KODPersonalAccount.Controllers.Directions;

public class DirectionController : 
    Controller
{
    private readonly IDirectionAppService _directionAppService;

    public DirectionController(IDirectionAppService directionAppService)
    {
        _directionAppService = directionAppService;
    }
    
    public async Task<ActionResult<Direction>> GetAsync(
        string title)
    {
        var direction = await _directionAppService.GetAsync(
            title);
        
        if (direction is null)
            return NotFound();
        
        return Ok(direction);
    }

    public async Task<ActionResult<Direction>> CreateAsync(
        DirectionCreateDto input)
    {
        var direction = await _directionAppService.GetAsync(
            input.Title);

        if (direction is not null)
            return BadRequest("Данное направление уже существует.");
        
        var newDirection = await _directionAppService.CreateAsync(
            input);
        
        return Ok(newDirection);
    }

    public async Task<ActionResult<Direction>> UpdateAsync(
        string title, 
        DirectionUpdateDto input)
    {
        var direction = await _directionAppService.UpdateAsync(
            title,
            input);
        
        if (direction is null)
            return NotFound();
        
        return Ok(direction);
    }

    public async Task<ActionResult> DeleteAsync(string title)
    {
        var direction = await _directionAppService.GetAsync(
            title);
        
        if (direction is null)
            return NotFound();
        
        return Ok(direction);
    }
}