namespace KODPersonalAccount.Contracts.Lessons;

/// <summary>
/// DTO создания урока.
/// </summary>
public record LessonCreateDto
{
    /// <summary>
    /// Идентификатор группы.
    /// </summary>
    public Guid GroupId { get; set; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// Ссылка на запись урока.
    /// </summary>
    public string? RecordLink { get; set; }
}