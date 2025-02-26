using KODPersonalAccount.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace KODPersonalAccount.Interfaces;

public interface IDataRepository
{
    public Task AddLessonAttendance(LessonAttendance lessonAttendance);
    public Task AddUserToGroup(UserToGroup userToGroup);
    public Task DeleteLessonAttendance(LessonAttendance lessonAttendance);
    public Task DeleteUserToGroup(UserToGroup userToGroup);
}