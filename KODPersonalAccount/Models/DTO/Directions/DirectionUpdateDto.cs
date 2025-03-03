namespace KODPersonalAccount.Models.DTO;

/// <summary>
/// DTO обновления направления.
/// </summary>
public record DirectionUpdateDto
{
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; init; }
}
