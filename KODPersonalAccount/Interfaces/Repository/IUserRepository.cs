using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces.Repository;

public interface IUserRepository
{
    /// <summary>
    /// Get all users from range 
    /// </summary>
    /// <param name="page">Number of page</param>
    /// <param name="pageSize">Number of people per page</param>
    /// <param name="withoutGroup">flag for people leaving without a group (if true)</param>
    /// <returns>All user with the given flag, in the page range.</returns>
    Task<(IEnumerable<User> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize, bool withoutGroup = false);
    
    /// <summary>
    /// Get all sorted by points user from range.
    /// </summary>
    /// <param name="page">Number of page</param>
    /// <param name="pageSize">Number of people per page</param>
    /// <param name="descending">Sort flag descending</param>
    /// <returns>All sorted by points user, in the page range.</returns>
    Task<(IEnumerable<User> Users, int TotalCount)> GetSortedByPointsAsync(int page, int pageSize, bool descending = false);
    
    /// <summary>
    /// Get user by telegram id (primary key)
    /// </summary>
    /// <param name="id">telegram id</param>
    /// <returns>User with given id or NotFoundException</returns>
    Task<User?> GetUserByIdAsync(long id);
    
    /// <summary>
    /// Add user to DB
    /// </summary>
    /// <param name="user">User data</param>
    /// <returns>Operation Result</returns>
    Task<OperationResult> AddUserAsync(User user);
    
    /// <summary>
    /// Change of first or last name
    /// </summary>
    /// <param name="userId">telegram Id</param>
    /// <param name="oldName">old name</param>
    /// <param name="newName">new name</param>
    /// <param name="isLastname">flag to select first(false) or last(true) name</param>
    /// <returns>Operation Result</returns>
    Task<OperationResult> UpdateNameAsync(long userId, string newName, bool isLastname = false);
    
    /// <summary>
    /// Add points to user
    /// </summary>
    /// <param name="userId">telegram Id</param>
    /// <param name="pointsNumber">number of points</param>
    /// <returns>OperationResult</returns>
    Task<OperationResult> AddScoreToUserAsync(long userId, float pointsNumber);
    
    /// <summary>
    /// Update user data from telegram
    /// </summary>
    /// <param name="userId">telegram Id</param>
    /// <param name="tgUsername">telegram username</param>
    /// <param name="imageUrl">url to telegram photo</param>
    /// <returns>Operation Result</returns>
    Task<OperationResult> UpdateTelegramDataAsync(long userId, string tgUsername, string imageUrl);
    
    
    /// <summary>
    /// Delete user in table
    /// </summary>
    /// <param name="id">telegram Id</param>
    Task DeleteUserAsync(long id);
}