using KODPersonalAccount.Models.DTO;

namespace KODPersonalAccount.Interfaces.Services;

public interface IAuthService
{
    Task<TokenOutputDto?> AuthAsync(string initData);
    Task<TokenOutputDto?> RefreshTokenAsync(string refreshToken);
}