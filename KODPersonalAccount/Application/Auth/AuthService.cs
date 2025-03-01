using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Interfaces.Services;
using KODPersonalAccount.Models.DTO;
using KODPersonalAccount.Models.DTO.Token;
using KODPersonalAccount.Models.Entity;
using KODPersonalAccount.Models.Strunctures;

namespace KODPersonalAccount.Services;

public class AuthService(ITokenGeneratorService tokenGenerator, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
    : IAuthService
{
    private readonly ITokenGeneratorService _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly ITelegramAuthService _telegramAuthService = new TelegramAuthService("../tg.token");

    public async Task<TokenOutputDto?> AuthAsync(string initData)
    {
        TelegramUser? telegramUser = await _telegramAuthService.GetUserFromInitDataAsync(initData);
        if (telegramUser == null)
        { return null; }
        User? user = await _userRepository.GetUserByIdAsync(telegramUser.Id);
        if (user == null)
        {
            user = new User()
            {
                Id = telegramUser.Id,
                Role = "user",
                TgUsername = telegramUser.Username,
                FirstName = telegramUser.FirstName,
                LastName = telegramUser.LastName,
                ImageUrl = telegramUser.PhotoUrl,
                Points = 0
            };
            
            if(!(await _userRepository.AddUserAsync(user)).IsSuccess)
            {
                throw new Exception("New user is not register in AUTH");
            }
        }

        await _refreshTokenRepository.DeleteActiveTokenByIdAsync(user.Id);

        var accessToken = _tokenGenerator.GenerateAccessToken(user.Id.ToString(), user.Role);
        var refreshToken = _tokenGenerator.GenerateRefreshToken(user.Id.ToString());

        await _refreshTokenRepository.ReplaceEmptyToken(user.Id, refreshToken);
        return new TokenOutputDto(accessToken, refreshToken);
    }

    public async Task<TokenOutputDto?> RefreshTokenAsync(string refreshToken)
    {
        User? user = await _refreshTokenRepository.GetUserByTokenAsync(refreshToken);
        if (user == null)
        { return null;}
        var newAccessToken = _tokenGenerator.GenerateAccessToken(user.Id.ToString(),user.Role);
        var newRefreshToken = _tokenGenerator.GenerateRefreshToken(user.Id.ToString());

        var result = await _refreshTokenRepository.UpdateTokenAsync(refreshToken, newRefreshToken);
        if (!result.IsSuccess)
        { return null; }

        return new TokenOutputDto(newAccessToken, newRefreshToken);
    }
}