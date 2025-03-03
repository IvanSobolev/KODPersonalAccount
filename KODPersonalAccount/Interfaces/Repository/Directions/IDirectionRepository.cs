using KODPersonalAccount.Applications.Models.Entity;

namespace KODPersonalAccount.Applications.Interfaces.Repository;

/// <summary>
/// Репозиторий направления.
/// </summary>
public interface IDirectionRepository
{
    /// <summary>
    /// Получить направление.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <returns>Направление.</returns>
    Task<Direction?> GetAsync(
        string title);

    /// <summary>
    /// Создать направление.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="description">Описание.</param>
    /// <returns>Направление.</returns>
    Task<Direction> CreateAsync(
        string title,
        string description);
    
    /// <summary>
    /// Обновить направление.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="description">Описание.</param>
    /// <returns>Обновлённое направление.</returns>
    Task<Direction?> UpdateAsync(
        string title,
        string description);
    
    /// <summary>
    /// Удалить направление.
    /// </summary>
    /// <param name="title">Название.</param>
    Task DeleteAsync(
        string title);
}
