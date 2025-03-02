namespace KODPersonalAccount.Applications.Models.DTO;

/// <summary>
/// DTO обновления пользователя.
/// </summary>
public record UserUpdateDto
{
    /// <summary>
    /// Новое имя.
    /// </summary>
    public string NewName { get; set; }

    /// <summary>
    /// Это фамилия.
    /// </summary>
    public bool IsLastName { get; set; }
}
