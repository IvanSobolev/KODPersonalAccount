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
    /// Направление.
    /// </summary>
    public string? Direction { get; set; }
    
    /// <summary>
    /// Идентификатор педагога.
    /// </summary>
    public long? TeacherId { get; set; }
    
    /// <summary>
    /// Студенты.
    /// </summary>
    public List<User>? Students { get; set; }

    /// <summary>
    /// Создание на основе первичных данных.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="schedule">Расписание занятий.</param>
    /// <param name="direction">Направление.</param>
    /// <param name="teacherId">Идентификатор педагога.</param>
    /// <param name="students">Студенты.</param>
    /// <param name="studyYears">Год обучения.</param>
    public Group(
        Guid id,
        string? schedule,
        string direction,
        long? teacherId,
        List<User?> students,
        int studyYears = 1)
    {
        Id = id;
        StudyYears = studyYears;
        Direction = direction;
        Students = new();

        if (students is not null)
        {
            SetStudents(
                students);
        }
        
        if (teacherId is not null)
        {
            TeacherId = teacherId;
        }

        if (students is not null)
        {
            SetStudents(
                students);
        }
    }

    private Group()
    {
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
    /// <param name="students">Студенты.</param>
    public void SetStudents(
        List<User> students)
    {
        if (students.Count > 0)
            foreach (var student in students)
                if (!Students.Contains(student))
                    Students.Add(student);
    }
}