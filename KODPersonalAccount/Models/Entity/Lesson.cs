namespace KODPersonalAccount.Models.Entity;

public class Lesson
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string RecordLink { get; set; }

    public long GroupId { get; set; }

    public Group Group { get; set; }
    public ICollection<LessonAttendance> Attendances { get; set; }
}