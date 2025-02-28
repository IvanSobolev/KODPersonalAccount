using KODPersonalAccount.Contracts.Lessons;
using KODPersonalAccount.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KODPersonalAccount.Controllers.Lessons;

[ApiController]
[Route("lesson/[controller]")]
public class LessonController : 
    Controller
{
    private readonly ILessonAppService _lessonAppService;

    public LessonController(ILessonAppService lessonAppService)
    {
        _lessonAppService = lessonAppService;
    }
    
    [HttpGet ("{id:guid}")]
    public async Task<ActionResult<Lesson>> GetAsync(
        Guid id)
    {
        var lesson = await _lessonAppService.GetAsync(
            id);
        
        if (lesson is null) 
            return NotFound();
        
        return Ok(lesson);
    }

    [HttpGet]
    public async Task<ActionResult<List<Lesson>>> GetListAsync(
        long? groupId)
    {
        var lessons = await _lessonAppService.GetListAsync(
            groupId);
        
        return Ok(lessons);
    }

    [HttpPost]
    public async Task<ActionResult<Lesson>> CreateAsync(
        [FromBody]LessonCreateDto input)
    {
        var lesson = await _lessonAppService.CreateAsync(
            input);
        
        return Ok(lesson);
    }

    [HttpPut ("{id:guid}")]
    public async Task<ActionResult<Lesson>> UpdateAsync(Guid id, LessonUpdateDto input)
    {
        var lesson = await _lessonAppService.UpdateAsync(
            id,
            input);
        
        if (lesson is null)
            return NotFound();
        
        return Ok(lesson);
    }

    [HttpDelete ("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(
        Guid id)
    {
        var lesson = await _lessonAppService.GetAsync(
            id);
        
        if (lesson is null)
            return NotFound();
        
        await _lessonAppService.DeleteAsync(
            id);
        
        return NoContent();
    }
}