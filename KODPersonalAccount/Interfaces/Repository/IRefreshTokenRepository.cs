using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces.Repository;

public interface IRefreshTokenRepository
{
    /// <summary>
    /// Get user by refreshToken 
    /// </summary>
    /// <param name="token">refresh token</param>
    /// <returns>User with given refresh token or NotFoundException</returns>
    Task<User?> GetUserByTokenAsync(string token);
    
    /// <summary>
    /// Replace empty refresh token for the user with id
    /// </summary>
    /// <param name="id">telegram Id</param>
    /// <param name="token">new refresh token</param>
    /// <returns>Operation Result</returns>
    Task<OperationResult> ReplaceEmptyToken(long id, string token);
    
    /// <summary>
    /// Update refresh token
    /// </summary>
    /// <param name="oldToken">old refresh token</param>
    /// <param name="newToken">new refresh tokebn</param>
    /// <returns>Operation Result</returns>
    Task<OperationResult> UpdateTokenAsync(string oldToken, string newToken);
    
    /// <summary>
    /// Delete active refresh token for the user with id
    /// </summary>
    /// <param name="id">telegram Id</param>
    Task DeleteActiveTokenByIdAsync(long id);
}