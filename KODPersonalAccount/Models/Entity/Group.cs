namespace KODPersonalAccount.Models.Entity;

/// <summary>
/// Группа.
/// </summary>
public class Group
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Год обучения.
    /// </summary>
    public int StudyYears { get; set; }

    /// <summary>
    /// Расписание занятий.
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
    /// Идентификатор студентов.
    /// </summary>
    public List<long>? StudentIds { get; set; }

    /// <summary>
    /// Создание на основе первичных данных.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="schedule">Расписание занятий.</param>
    /// <param name="directionId">Идентификатор направления.</param>
    /// <param name="teacherId">Идентификатор педагога.</param>
    /// <param name="studentIds">Идентификатор студентов.</param>
    /// <param name="studyYears">Год обучения.</param>
    public Group(
        Guid id,
        string? schedule,
        long directionId,
        long? teacherId,
        List<long>? studentIds,
        int studyYears = 1)
    {
        Id = id;
        StudyYears = studyYears;
        DirectionId = directionId;
        StudentIds = new();

        if (studentIds is not null)
        {
            SetStudentIds(
                studentIds);
        }
        
        if (teacherId is not null)
        {
            TeacherId = teacherId;
        }

        if (studentIds is not null)
        {
            SetStudentIds(
                studentIds);
        }
        
    }

    /// <summary>
    /// Установить расписание.
    /// </summary>
    /// <param name="schedule">Расписание.</param>
    public void SetSchedule(
        string schedule)
    {
        schedule = schedule.Trim();

        if (!string.IsNullOrEmpty(schedule))
        {
            Schedule = schedule;
        }
    }
    
    /// <summary>
    /// Добавить студентов.
    /// </summary>
    /// <param name="studentIds">Идентификаторы студентов.</param>
    public void SetStudentIds(
        List<long> studentIds)
    {
        if (studentIds.Count > 0)
            foreach (long studentId in studentIds)
                if (!StudentIds.Contains(studentId))
                    StudentIds.Add(studentId);
    }
}