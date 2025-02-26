using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces;

public interface IGroupRepository
{
    Task<(IEnumerable<Group> Groups, int TotalCount)> GetAllGroupsAsync(int page, int pageSize);
    Task<(IEnumerable<Group> Groups, int TotalCount)> GetPublicGroupAsync(int page, int pageSize);
    Task<Group> GetGroupByIdAsync(long id);
    Task<OperationResult> AddUserToGroupAsync(long userId, long groupId);
    Task<OperationResult> AddGroupAsync(Group group);
    Task<OperationResult> UpdateGroupAsync(Group group);
    Task<OperationResult> DeleteGroupAsync(long id);
}