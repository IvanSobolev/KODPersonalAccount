using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.EntityFrameworkCore.Implementation.Repository;

/// <inheritdoc cref="IGroupRepository"/>
public class GroupRepository :
    IGroupRepository
{
    private readonly DataContext _context;

    public GroupRepository(DataContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc/>
    public async Task<Group?> GetAsync(
        Guid id)
    {
        return await _context.Groups.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
    }

    /// <inheritdoc/>
    public async Task<List<Group>> GetListAsync(
        int? studyYears, 
        string? schedule, 
        long? directionId,
        long? teacherId,
        long? studentId)
    {
        var query = await _context.Groups.AsNoTracking().ToListAsync();

        if (studyYears is not null)
        {
            query = query.Where(g => g.StudyYears == studyYears).ToList();
        }

        if (schedule is not null)
        {
            query = query.Where(g => g.Schedule == schedule).ToList();
        }

        if (directionId is not null)
        {
            query = query.Where(g => g.DirectionId == directionId).ToList();
        }

        if (teacherId is not null)
        {
            query = query.Where(g => g.TeacherId == teacherId).ToList();
        }

        if (studentId is not null)
        {
            var user = _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == studentId);

            if (user is not null)
            {
                query = query.Where(g => g.Students.Any(s => s.Id == user.Id)).ToList();
            }
        }
        
        return query;
    }

    /// <inheritdoc/>
    public async Task<Group> CreateAsync(
        string? schedule,
        long directionId,
        long? teacherId,
        List<long>? studentIds,
        int studyYears = 1)
    {
        List<User?> students = new();
        if (studentIds is { Count: > 0 })
        {
            foreach (var studedentId in studentIds)
            {
                students.Add(await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == studedentId));
            }
        }

        var group = new Group(
            id: Guid.NewGuid(),
            schedule: schedule,
            directionId: directionId,
            teacherId: teacherId,
            students: students,
            studyYears: studyYears);
        
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
        
        return group;
    }

    /// <inheritdoc/>
    public async Task<Group?> UpdateAsync(
        Guid id,
        int? studyYears,
        string? schedule,
        long? directionId,
        long? teacherId,
        List<long>? studentIds)
    {
        var group = await GetAsync(
            id);

        if (group is null)
            return null;
        
        if (studyYears is not null)
        {
            group.StudyYears = studyYears.Value;
        }

        if (schedule is not null)
        {
            group.SetSchedule(
                schedule);
        }

        if (directionId is not null)
        {
            if (await _context.Directions.AsNoTracking().AnyAsync(d => d.Id == directionId))
            {
                group.DirectionId = directionId.Value;
            }
        }
        
        if (teacherId is not null)
        {
            if (await _context.Users.AsNoTracking().AnyAsync(d => d.Id == teacherId))
            {
                group.TeacherId = teacherId.Value;
            }
        }

        if (studentIds is not null && studentIds.Count > 0)
        {
            List<User> students = new();
            foreach (var studentId in studentIds)
            {
                var student = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == studentId);
                if (student is not null)
                    students.Add(student);
            }
            
            group.SetStudents(
                students);
        }
        
        _context.Groups.Update(group);
        await _context.SaveChangesAsync();
        
        return group;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        Guid id)
    {
        var group = await GetAsync(
            id);
        
        if (group is null)
            return;
        
        _context.Groups.Remove(group);
    }
}