using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces;

public interface IUserRepository
{
    Task<(IEnumerable<User> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize);
    Task<(IEnumerable<User> Users, int TotalCount)> GetSortedByPointsAsync(int page, int pageSize, bool descending = true);
    Task<(IEnumerable<User> Users, int TotalCount)> GetUsersWithoutGroupAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(long id);
    Task<OperationResult> AddUserAsync(User user);
    Task<OperationResult> UpdateFirstNameAsync(long userId, string oldName, string newName);
    Task<OperationResult> UpdateSecondNameAsync(long userId, string oldName, string newName);
    Task<OperationResult> AddScoreToUserAsync(long userId, float score);
    Task<OperationResult> UpdateUserAsync(User user);
    Task<OperationResult> DeleteUserAsync(long id);
}