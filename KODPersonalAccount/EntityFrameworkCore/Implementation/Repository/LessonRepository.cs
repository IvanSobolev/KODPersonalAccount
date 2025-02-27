using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.EntityFrameworkCore.Implementation.Repository;

/// <inheritdoc cref="ILessonRepository"/>
public class LessonRepository :
    ILessonRepository
{
    private readonly DataContext _context;

    public LessonRepository(DataContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc/>
    public async Task<Lesson?> GetAsync(
        Guid id)
    {
        var lesson = await _context.Lessons.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        
        return lesson;
    }

    /// <inheritdoc/>
    public async Task<List<Lesson>> GetListAsync(
        long? groupId)
    {
        var lessons = await _context.Lessons.AsNoTracking().ToListAsync();

        if (groupId is not null)
        {
            lessons = lessons.Where(l => l.GroupId == groupId).ToList();
        }
        
        return lessons;
    }

    /// <inheritdoc/>
    public async Task<Lesson> CreateAsync(
        long groupId, 
        string title, 
        DateTime? date, 
        string? recordLink)
    {
        Lesson lesson = new(
            id: Guid.NewGuid(),
            groupId: groupId,
            title: title,
            date: date,
            recordLink: recordLink);
        
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
        
        return lesson;
    }

    /// <inheritdoc/>
    public async Task<Lesson?> UpdateAsync(
        Guid id, 
        string? title, 
        DateTime? date, 
        string? recordLink,
        List<long>? attendanceIds)
    {
        var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);

        if (lesson is null)
            return null;
        
        if (title is not null)
        {
            lesson.SetTitle(
                title);
        }
        if (date is not null)
        {
            lesson.Date = date;
        }
        if (recordLink is not null)
        {
            lesson.SetRecordLink(
                recordLink);
        }

        if (attendanceIds is not null && attendanceIds.Count > 0)
        {
            lesson.SetAttendanceIds(
                attendanceIds);
        }

        _context.Update(lesson);
        await _context.SaveChangesAsync();
        
        return lesson;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        Guid id)
    {
        var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);

        if (lesson is null)
            return;
        
        _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync();
    }
}