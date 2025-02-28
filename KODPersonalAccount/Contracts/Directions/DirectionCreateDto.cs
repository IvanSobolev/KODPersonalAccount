namespace KODPersonalAccount.Contracts.Directions;

/// <summary>
/// DTO создания направления.
/// </summary>
public record DirectionCreateDto
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; init; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; init; }
}