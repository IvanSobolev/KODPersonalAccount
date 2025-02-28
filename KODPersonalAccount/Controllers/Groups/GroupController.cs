using KODPersonalAccount.Contracts.Groups;
using KODPersonalAccount.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KODPersonalAccount.Controllers.Groups;

[ApiController]
[Route("group/[controller]")]
public class GroupController :
    Controller
{
    private readonly IGroupAppService _groupAppService;

    public GroupController(IGroupAppService groupAppService)
    {
        _groupAppService = groupAppService;
    }

    [HttpGet("{groupId:guid}")]
    public async Task<ActionResult<Group?>> GetAsync(
        Guid id)
    {
        var group = await _groupAppService.GetAsync(
            id);
        
        if (group is null)
            return NotFound();
        
        return Ok(group);
    }

    [HttpGet]
    public async Task<ActionResult<List<Group>>> GetListAsync(
        int? studyYears,
        string? schedule,
        string? direction,
        long? teacherId,
        long? studentId)
    {
        var groups = await _groupAppService.GetListAsync(
            studyYears,
            schedule,
            direction,
            teacherId,
            studentId);
        
        return Ok(groups);
    }

    [HttpPost]
    public async Task<ActionResult<Group>> CreateAsync(
        [FromBody]GroupCreateDto input)
    {
        var group = await _groupAppService.CreateAsync(
            input);
        
        return Ok(group);
    }

    [HttpPut("{groupId:guid}")]
    public async Task<ActionResult<Group?>> UpdateAsync(
        Guid id,
        [FromBody]GroupUpdateDto input)
    {
        var group = await _groupAppService.UpdateAsync(
            id,
            input);
        
        return Ok(group);
    }

    [HttpDelete("{groupId:guid}")]
    public async Task<ActionResult> DeleteAsync(
        Guid id)
    {
        var group = await _groupAppService.GetAsync(
            id);
        
        if (group is null)
            return NotFound();
        
        await _groupAppService.DeleteAsync(id);
        return NoContent();
    }
}