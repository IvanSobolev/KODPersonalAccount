using KODPersonalAccount.Applications.Interfaces.Repository;
using KODPersonalAccount.Applications.Interfaces.Services.Users;
using KODPersonalAccount.Applications.Models.DTO;
using KODPersonalAccount.Applications.Models.Entity;
using KODPersonalAccount.Applications.Models.Strunctures;

namespace KODPersonalAccount.Applications;

/// <inheritdoc cref="IUserAppService"/>
public class UserAppService(IUserRepository userRepository) : IUserAppService
{
    private IUserRepository _userRepository = userRepository;

    /// <inheritdoc/>
    public async Task<(IEnumerable<User> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize)
    {
        return await _userRepository.GetAllUsersAsync(page, pageSize);
    }
    
    /// <inheritdoc/>   
    public async Task<(IEnumerable<User> Users, int TotalCount)> GetSortedByPointsAsync(int page, int pageSize, bool descending = false)
    {
        return await _userRepository.GetSortedByPointsAsync(page, pageSize, descending);
    }
    
    /// <inheritdoc/>
    public async Task<User?> GetUserByIdAsync(long id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }
    
    /// <inheritdoc/>
    public async Task<OperationResult> AddUserAsync(UserAddDto user)
    {
        return await _userRepository.AddUserAsync(new User()
        {
            Id = user.TelegramId,
            Role = "Учасник",
            TgUsername = user.TelegramUsername,
            FirstName = user.FirstUsername,
            LastName = user.LastUsername,
            ImageUrl = user.ImageUrl,
            Points = 0,
            RefreshToken = "",
            ExpiresToken = DateTime.Now
        });
    }
    
    /// <inheritdoc/>
    public async Task<OperationResult> UpdateNameAsync(long userId, string newName, bool isLastname = false)
    {
        return await _userRepository.UpdateNameAsync(userId, newName, isLastname);
    }
    
    /// <inheritdoc/>
    public async Task<OperationResult> AddScoreToUserAsync(long userId, float pointsNumber)
    {
        return await _userRepository.AddScoreToUserAsync(userId, pointsNumber);
    }
    
    /// <inheritdoc/>
    public async Task<OperationResult> UpdateTelegramDataAsync(TelegramUser user)
    {
        return await _userRepository.UpdateTelegramDataAsync(user.Id, user.Username, user.PhotoUrl);
    }
    
    /// <inheritdoc/>
    public async Task DeleteUserAsync(long id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
}
