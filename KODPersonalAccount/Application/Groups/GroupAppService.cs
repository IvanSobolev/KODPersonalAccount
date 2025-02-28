using KODPersonalAccount.Contracts.Groups;
using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Application.Groups;

/// <inheritdoc cref="IGroupAppService"/>
public class GroupAppService : 
    IGroupAppService
{
    private readonly IGroupRepository _groupRepository;

    public GroupAppService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    /// <inheritdoc/>
    public async Task<Group?> GetAsync(
        Guid id)
    {
        return await _groupRepository.GetAsync(
            id);
    }

    /// <inheritdoc/>
    public async Task<List<Group>> GetListAsync(
        int? studyYears, 
        string? schedule, 
        string? direction,
        long? teacherId,
        long? studentId)
    {
        return await _groupRepository.GetListAsync(
            studyYears: studyYears,
            schedule: schedule,
            direction: direction,
            teacherId: teacherId,
            studentId: studentId);
    }

    /// <inheritdoc/>
    public async Task<Group> CreateAsync(
        GroupCreateDto input)
    {
        return await _groupRepository.CreateAsync(
            schedule: input.Schedule,
            direction: input.Direction,
            teacherId: input.TeacherId,
            studentIds: input.StudentIds,
            studyYears: input.StudyYears);
    }

    /// <inheritdoc/>
    public async Task<Group?> UpdateAsync(
        Guid id,
        GroupUpdateDto input)
    {
        return await _groupRepository.UpdateAsync(
            id: id,
            studyYears: input.StudyYears,
            schedule: input.Schedule,
            direction: input.Direction,
            teacherId: input.TeacherId,
            studentIds: input.StudentIds);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        Guid id)
    {
        await _groupRepository.DeleteAsync(
            id);
    }
}