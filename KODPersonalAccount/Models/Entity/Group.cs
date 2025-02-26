namespace KODPersonalAccount.Models.Entity;

public class Group
{
    public long Id { get; set; }
    public bool IsPrivate { get; set; }
    public string Color { get; set; }
    public int StudyYears { get; set; }

    public long DirectionId { get; set; }
    public long TeacherId { get; set; }
    
    public Direction Direction { get; set; }
    public User Teacher { get; set; }
    public ICollection<UserToGroup> UserToGroups { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
}