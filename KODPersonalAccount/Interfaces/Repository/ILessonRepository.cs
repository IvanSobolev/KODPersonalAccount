using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces.Repository;

/// <summary>
/// Репозиторий урока.
/// </summary>
public interface ILessonRepository
{
    /// <summary>
    /// Получить урок.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Урок.</returns>
    Task<Lesson?> GetAsync(
        Guid id);
    
    /// <summary>
    /// Получить список уроков.
    /// </summary>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <returns>Список уроков.</returns>
    Task<List<Lesson>> GetListAsync(
        long? groupId);
    
    /// <summary>
    /// Создать урок.
    /// </summary>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <param name="title">Название.</param>
    /// <param name="date">Дата проведения.</param>
    /// <param name="recordLink">Ссылка на запись.</param>
    /// <returns>Урок.</returns>
    Task<Lesson> CreateAsync(
        long groupId,
        string title,
        DateTime? date,
        string? recordLink);

    /// <summary>
    /// Обновить урок.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название.</param>
    /// <param name="date">Дата проведения.</param>
    /// <param name="recordLink">Ссылка на запись.</param>
    /// <param name="attendanceIds">Идентификатор присутствующих студентов.</param>
    /// <returns>Обновлённый урок.</returns>
    Task<Lesson?> UpdateAsync(
        Guid id,
        string? title,
        DateTime? date,
        string? recordLink,
        List<long>? attendanceIds);
    
    /// <summary>
    /// Удалить урок.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(
        Guid id);
}