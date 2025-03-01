using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Contracts.Groups;

/// <summary>
/// Сервис группы.
/// </summary>
public interface IGroupAppService
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
    /// <param name="direction">Направление.</param>
    /// <param name="teacherId">Идентификатор педагога.</param>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Список групп.</returns>
    Task<List<Group>> GetListAsync(
        int? studyYears, 
        string? schedule, 
        string? direction,
        long? teacherId,
        long? studentId);
    
    /// <summary>
    /// Создать группу.
    /// </summary>
    /// <param name="input">Данные для создания группы.</param>
    /// <returns>Группа.</returns>
    Task<Group> CreateAsync(
        GroupCreateDto input);

    /// <summary>
    /// Обновить группу.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="input">Данные для обновления группы.</param>
    /// <returns>Обновленная группа.</returns>
    Task<Group?> UpdateAsync(
        Guid id,
        GroupUpdateDto input);
    
    /// <summary>
    /// Удалить группу.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(
        Guid id);
}