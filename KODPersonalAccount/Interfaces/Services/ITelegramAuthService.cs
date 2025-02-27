using KODPersonalAccount.Models.DTO;

namespace KODPersonalAccount.Interfaces.Services;

public interface ITelegramAuthService
{
    Task<TelegramUser> GetUserFromInitDataAsync(string initData);
    Task<bool> ValidateInitDataAsync(string initData, string botToken);
    Task<TelegramUser> ExtractUserFromInitDataAsync(string initData);
}