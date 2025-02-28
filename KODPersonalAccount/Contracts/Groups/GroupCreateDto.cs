namespace KODPersonalAccount.Contracts.Groups;

/// <summary>
/// DTO создания группы. 
/// </summary>
public record GroupCreateDto
{
    /// <summary>
    /// Год обучения.
    /// </summary>
    public int StudyYears { get; init; }
    
    /// <summary>
    /// Расписание.
    /// </summary>
    public string? Schedule { get; set; }
    
    /// <summary>
    /// Идентификатор направления.
    /// </summary>
    public long DirectionId { get; set; }
    
    /// <summary>
    /// Идентификатор педагога.
    /// </summary>
    public long? TeacherId { get; set; }
    
    /// <summary>
    /// Студенты.
    /// </summary>
    public List<long>? StudentIds { get; set; }
}