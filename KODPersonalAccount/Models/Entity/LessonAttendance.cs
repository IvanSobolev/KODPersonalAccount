namespace KODPersonalAccount.Models.Entity;

public class LessonAttendance
{
    public long LessonId { get; set; }
    public long UserId { get; set; }

    public Lesson Lesson { get; set; }
    public User User { get; set; }
}