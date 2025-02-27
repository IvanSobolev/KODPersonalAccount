using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Contracts.Lessons;

/// <summary>
/// Сервис урока.
/// </summary>
public interface ILessonAppService
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
    /// <param name="input">Данные для создания урока.</param>
    /// <returns>Урок.</returns>
    Task<Lesson> CreateAsync(
        LessonCreateDto input);

    /// <summary>
    /// Обновить урок.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="input">Данные для создания урока.</param>
    /// <returns>Обновлённый урок.</returns>
    Task<Lesson?> UpdateAsync(
        Guid id,
        LessonUpdateDto input);
    
    /// <summary>
    /// Удалить урок.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    Task DeleteAsync(
        Guid id);
}