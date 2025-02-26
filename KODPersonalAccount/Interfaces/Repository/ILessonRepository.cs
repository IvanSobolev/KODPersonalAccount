using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces;

public interface ILessonRepository
{
    Task<(IEnumerable<Lesson> lessons, int TotalCount)> GetAllDateSortedLessonsAsync(int page, int pageSize);
    Task<(IEnumerable<Lesson> lessons, int TotalCount)> GetDateSortedLessonsForGroupAsync(long groupId, int page, int pageSize);
    Task<Lesson> GetLessonByIdAsync(long id);
    Task<OperationResult> AddLessonAsync(Lesson lesson);
    Task<OperationResult> MarkAttendanceAsync(long lessonId, long userId);
    Task<OperationResult> UploadLessonRecordAsync(long lessonId, string recordLink);
    Task<OperationResult> RenameAsync(long lessonId, string newName);
    Task<OperationResult> DeleteLesson(long id);
}