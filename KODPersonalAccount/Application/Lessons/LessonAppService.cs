using KODPersonalAccount.Contracts.Lessons;
using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Application.Lessons;

/// <inheritdoc cref="ILessonAppService"/>
public class LessonAppService :
    ILessonAppService
{
    private readonly ILessonRepository _lessonRepository;

    public LessonAppService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }
    
    /// <inheritdoc/>
    public async Task<Lesson?> GetAsync(
        Guid id)
    {
        return await _lessonRepository.GetAsync(
            id);
    }

    /// <inheritdoc/>
    public async Task<List<Lesson>> GetListAsync(
        long? groupId)
    {
        return await _lessonRepository.GetListAsync(
            groupId);
    }

    /// <inheritdoc/>
    public async Task<Lesson> CreateAsync(
        LessonCreateDto input)
    {
        return await _lessonRepository.CreateAsync(
            groupId: input.GroupId,
            title: input.Title,
            date: input.Date,
            recordLink: input.RecordLink);
    }

    /// <inheritdoc/>
    public async Task<Lesson?> UpdateAsync(
        Guid id, 
        LessonUpdateDto input)
    {
        return await _lessonRepository.UpdateAsync(
            id: id,
            title: input.Title,
            date: input.Date,
            recordLink: input.RecordLink,
            attendanceIds: input.AttendanceIds);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        Guid id)
    {
        await _lessonRepository.DeleteAsync(
            id);
    }
}