using KODPersonalAccount.Models.DTO;

namespace KODPersonalAccount.Interfaces.Services;

public interface ITelegramAuthService
{
    Task<TelegramUser> GetUserFromInitData(string initData);
    Task<bool> ValidateInitData(string initData, string botToken);
    Task<TelegramUser> ExtractUserFromInitData(string initData);
}