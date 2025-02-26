namespace KODPersonalAccount.Models.Entity;

public class User
{
    public long Id { get; set; }
    public string Role { get; set; }
    public string TgUsername { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Points { get; set; }
    public string ImageUrl { get; set; }
    
    public ICollection<UserToGroup> UserToGroups { get; set; }
    public ICollection<LessonAttendance> LessonAttendances { get; set; }
    public ICollection<Group> TaughtGroups { get; set; }
}