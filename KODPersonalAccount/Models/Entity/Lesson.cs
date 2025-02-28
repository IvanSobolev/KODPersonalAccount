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
    public Guid? GroupId { get; init; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; private set; }
    
    /// <summary>
    /// Дата проведения.
    /// </summary>
    public DateTime? Date { get; set; }
    
    /// <summary>
    /// Ссылка на запись урока.
    /// </summary>
    public string? RecordLink { get; private set; }
    
    /// <summary>
    /// Идентификатор присутствующих студентов.
    /// </summary>
    public List<User> Attendances { get; private set; }

    /// <summary>
    /// Создание на основе первичных данных.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <param name="title">Название.</param>
    /// <param name="date">Дата проведения.</param>
    /// <param name="recordLink">Ссылка на запись.</param>
    public Lesson(
        Guid id,
        Guid groupId,
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
        Attendances = new();
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

    /// <summary>
    /// Установить присутствующих студентов.
    /// </summary>
    /// <param name="attendances">Присутствующие студенты.</param>
    public void SetAttendances(
        List<User> attendances)
    {
        if (attendances.Count > 0)
            foreach (var attendance in attendances)
                if (!Attendances.Contains(attendance))
                    Attendances.Add(attendance);
    }
}