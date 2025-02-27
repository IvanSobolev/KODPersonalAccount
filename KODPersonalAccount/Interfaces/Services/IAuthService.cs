using KODPersonalAccount.Models.DTO;

namespace KODPersonalAccount.Interfaces.Services;

public interface IAuthService
{
    Task<TokenOutputDto?> Auth(string initData);
    Task<TokenOutputDto?> RefreshToken(string refreshToken);
}