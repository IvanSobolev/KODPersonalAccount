namespace KODPersonalAccount.Models.Entity;

/// <summary>
/// Урок.
/// </summary>
public class Lesson
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор группы.
    /// </summary>
    public long GroupId { get; init; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; private set; }
    
    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// Запись урока.
    /// </summary>
    public string? RecordLink { get; private set; }
    
    /// <summary>
    /// Идентификатор присутствующих студентов.
    /// </summary>
    public List<long> AttendanceIds { get; private set; }

    /// <summary>
    /// Создание на основе первичных данных.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="title">Название.</param>
    /// <param name="date">Дата проведения.</param>
    /// <param name="recordLink">Ссылка на запись.</param>
    public Lesson(
        Guid id,
        long groupId,
        string title,
        DateTime? date,
        string? recordLink)
        :this()
    {
        Id = id;
        GroupId = groupId;
        Date = date;
        
        SetTitle(
            title);
        
        if (recordLink != null)
        {
            SetRecordLink(
                recordLink);
        }
    }

    private Lesson()
    {
        AttendanceIds = new();
    }

    /// <summary>
    /// Установить название.
    /// </summary>
    /// <param name="title">Название.</param>
    public void SetTitle(
        string title)
    {
        title = title.Trim();
        if (!string.IsNullOrEmpty(title))
        {
            Title = title;
        }
    }
    
    /// <summary>
    /// Установить ссылку на запись.
    /// </summary>
    /// <param name="recordLink">Ссылка на запись.</param>
    public void SetRecordLink(
        string recordLink)
    {
        recordLink = recordLink.Trim();
        if (!String.IsNullOrEmpty(recordLink))
        {
            RecordLink = recordLink;
        }
    }

    public void SetAttendanceIds(
        List<long> attendanceIds)
    {
        if (attendanceIds.Count > 0)
            foreach (var attendanceId in attendanceIds)
                if (!AttendanceIds.Contains(attendanceId))
                    AttendanceIds.Add(attendanceId);
    }
}