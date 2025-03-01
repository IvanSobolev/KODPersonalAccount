using KODPersonalAccount.Models.DTO;
using KODPersonalAccount.Models.DTO.Token;

namespace KODPersonalAccount.Interfaces.Services;

public interface IAuthService
{
    Task<TokenOutputDto?> AuthAsync(string initData);
    Task<TokenOutputDto?> RefreshTokenAsync(string refreshToken);
}