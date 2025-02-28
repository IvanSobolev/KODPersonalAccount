namespace KODPersonalAccount.Models.Entity;

/// <summary>
/// Пользователь.
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Роль.
    /// </summary>
    public string Role { get; set; }
    
    /// <summary>
    /// Имя пользователя в Телеграме.
    /// </summary>
    public string TgUsername { get; set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Ссылка на аватарку пользователя.
    /// </summary>
    public string ImageUrl { get; set; }
    
    /// <summary>
    /// Баллы.
    /// </summary>
    public float Points { get; set; }
    
    /// <summary>
    /// Refresh-токен.
    /// </summary>
    public string RefreshToken { get; set; }
    
    /// <summary>
    /// Время жизни refresh-токена.
    /// </summary>
    public DateTime ExpiresToken { get; set; }
}