using System.Text.Json;
using System.Web;
using KODPersonalAccount.Interfaces.Services;
using KODPersonalAccount.Models.DTO;
using KODPersonalAccount.Models.Strunctures;

namespace KODPersonalAccount.Services;

public class TelegramAuthService(string botToken) : ITelegramAuthService
{
    private readonly string _botToken = botToken;

    public async Task<TelegramUser?> GetUserFromInitDataAsync(string initData)
    {
        if (!await ValidateInitDataAsync(initData, _botToken))
        {
            return null;
        }

        return await ExtractUserFromInitDataAsync(initData);
    }

    public async Task<bool> ValidateInitDataAsync(string initData, string botToken)
    {
        var parameters = HttpUtility.ParseQueryString(initData);
        var hash = parameters["hash"];
        parameters.Remove("hash");

        var sortedParameters = parameters.AllKeys.OrderBy(k => k)
                                                        .Select(k => $"{k}={parameters[k]}")
                                                        .ToArray();

        var dataCheckString = string.Join("\n", sortedParameters);
        var secretKey = await HashFunctionService.ComputeHmacSha256Async("WebAppData", botToken);
        var computedHash = await HashFunctionService.ComputeHmacSha256Async(secretKey, dataCheckString);

        return computedHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
    }

    public Task<TelegramUser?> ExtractUserFromInitDataAsync(string initData)
    {
        var parameters = HttpUtility.ParseQueryString(initData);
        var userJson = parameters["user"];

        if (string.IsNullOrEmpty(userJson))
        {
            return Task.FromResult<TelegramUser?>(null);
        }

        return Task.FromResult(JsonSerializer.Deserialize<TelegramUser>(userJson));
    }
}