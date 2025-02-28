using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces.Repository;

/// <summary>
/// Репозиторий группы.
/// </summary>
public interface IGroupRepository
{
    /// <summary>
    /// Получить группу.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Группа.</returns>
    Task<Group?> GetAsync(
        Guid id);
    
    /// <summary>
    /// Получить список групп.
    /// </summary>
    /// <param name="studyYears">Год обучения.</param>
    /// <param name="schedule">Расписание.</param>
    /// <param name="directionId">Идентификатор направления.</param>
    /// <param name="teacherId">Идентификатор педагога.</param>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Список групп.</returns>
    Task<List<Group>> GetListAsync(
        int? studyYears,
        string? schedule,
        long? directionId,
        long? teacherId,
        long? studentId);
    
    /// <summary>
    /// Создать группу.
    /// </summary>
    /// <param name="directionId">Идентификатор направления.</param>
    /// <param name="schedule">Расписание занятий.</param>
    /// <param name="teacherId">Идентификатор педагога.</param>
    /// <param name="studentIds">Идентификатор студентов.</param>
    /// <param name="studyYears">Год обучения.</param>
    /// <returns>Группа.</returns>
    Task<Group> CreateAsync(
        string? schedule,
        long directionId,
        long? teacherId,
        List<long>? studentIds, 
        int studyYears = 1);
    
    /// <summary>
    /// Обновить группу.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="studyYears">Год обучения.</param>
    /// <param name="schedule">Расписание.</param>
    /// <param name="directionId">Идентификатор направления.</param>
    /// <param name="teacherId">Идентификатор педагога.</param>
    /// <param name="studentIds">Идентификатор студентов.</param>
    /// <returns>Обновлённая группа.</returns>
    Task<Group?> UpdateAsync(
        Guid id,
        int? studyYears,
        string? schedule,
        long? directionId,
        long? teacherId,
        List<long>? studentIds);
    
    /// <summary>
    /// Удалить группу.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(
        Guid id);
}