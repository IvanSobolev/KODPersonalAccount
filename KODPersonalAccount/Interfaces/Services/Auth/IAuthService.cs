using KODPersonalAccount.Applications.Models.DTO;

namespace KODPersonalAccount.Applications.Interfaces.Services;

public interface IAuthService
{
    Task<TokenOutputDto?> AuthAsync(string initData);
    Task<TokenOutputDto?> RefreshTokenAsync(string refreshToken);
}
