using KODPersonalAccount.Models;
using KODPersonalAccount.Models.Entity;

namespace KODPersonalAccount.Interfaces;

public interface IRefreshTokenRepository
{
    Task<User?> GetUserByTokenAsync(string token);
    Task<OperationResult> SetEmptyToken(long id, string token);
    Task<OperationResult> UpdateTokenAsync(string oldToken, string newToken);
    Task<OperationResult> DeleteActiveTokenAsync(string token);
    Task<OperationResult> DeleteActiveTokenByIdAsync(long id);
}