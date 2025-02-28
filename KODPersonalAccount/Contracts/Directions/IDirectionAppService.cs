using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Contracts.Directions;

/// <summary>
/// Сервис направления.
/// </summary>
public interface IDirectionAppService
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
    /// <param name="input">Данные для создания направления.</param>
    /// <returns>Направление.</returns>
    Task<Direction> CreateAsync(
        DirectionCreateDto input);
    
    /// <summary>
    /// Обновить направление.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="input">Данные для обновления направления.</param>
    /// <returns>Обновлённое направление.</returns>
    Task<Direction?> UpdateAsync(
        string title,
        DirectionUpdateDto input);
    
    /// <summary>
    /// Удалить направление.
    /// </summary>
    /// <param name="title">Название.</param>
    Task DeleteAsync(
        string title);
}