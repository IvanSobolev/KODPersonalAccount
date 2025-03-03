namespace KODPersonalAccount.Models.DTO;

public record LessonUpdateDto
{
    /// <summary>
    /// Название.
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// Ссылка на запись урока.
    /// </summary>
    public string? RecordLink { get; set; }
    
    /// <summary>
    /// Идентификатор присутствующих студентов.
    /// </summary>
    public List<long>? AttendanceIds { get; set; }
}
