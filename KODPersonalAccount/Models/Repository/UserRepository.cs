using KODPersonalAccount.Interfaces.Repository;
using KODPersonalAccount.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.Models.Repository;

public class UserRepository(DataContext dataContext) : IUserRepository
{
    private readonly DataContext _context = dataContext;
    private int? _cachedTotalCount;

    public async Task<(IEnumerable<User> Users, int TotalCount)> GetAllUsersAsync(int page, int pageSize, bool withoutGroup = false)
    {
        if (page < 1 || pageSize < 1)
        { throw new ArgumentException("Page and pageSize must be greater than 0."); }
        
        var query = _context.Users.AsQueryable();
        _cachedTotalCount ??= await query.CountAsync();
        
        if (withoutGroup)
        { query = query.Where(u => !u.GroupsIds.Any()); }
        
        var users = await query.OrderBy(u => u.Id)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
        
        return (users, _cachedTotalCount.Value);
    }

    public async Task<(IEnumerable<User> Users, int TotalCount)> GetSortedByPointsAsync(int page, int pageSize, bool descending = false)
    {
        if (page < 1 || pageSize < 1)
        { throw new ArgumentException("Page and pageSize must be greater than 0."); }
        
        var query = _context.Users.AsQueryable();
        _cachedTotalCount ??= await query.CountAsync();

        query = descending ? 
            query.OrderByDescending(u => u.Points): 
            query.OrderBy(u => u.Points);

        var users = await query.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

        return (users, _cachedTotalCount.Value);
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new NullReferenceException("User not found");
        }

        return user;
    }

    public async Task<OperationResult> AddUserAsync(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (DbUpdateException ex)
        {
            return new OperationResult(false, "Database error occurred while adding the user.");
        }
        catch (Exception ex)
        {
            return new OperationResult(false, "An unexpected error occurred.");
        }
    }

    public async Task<OperationResult> UpdateNameAsync(long userId, string newName, bool isLastname = false)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            return new OperationResult(false, "User not found");
        }
        
        try
        {
            if (isLastname)
            {
                user.LastName = newName;
            }
            else
            {
                user.FirstName = newName;
            }
            await _context.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (DbUpdateException ex)
        {
            return new OperationResult(false, "Database error occurred while updating the user.");
        }
        catch (Exception ex)
        {
            return new OperationResult(false, "An unexpected error occurred.");
        }
    }

    public async Task<OperationResult> AddScoreToUserAsync(long userId, float pointsNumber)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            return new OperationResult(false, "User not found");
        }
        
        try
        {
            user.Points += pointsNumber;
            await _context.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (DbUpdateException ex)
        {
            return new OperationResult(false, "Database error occurred while updating the user.");
        }
        catch (Exception ex)
        {
            return new OperationResult(false, "An unexpected error occurred.");
        }
    }

    public async Task<OperationResult> UpdateTelegramDataAsync(long userId, string tgUsername, string imageUrl)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            return new OperationResult(false, "User not found");
        }
        
        try
        {
            user.TgUsername = tgUsername;
            user.ImageUrl = imageUrl;
            await _context.SaveChangesAsync();
            return new OperationResult(true);
        }
        catch (DbUpdateException ex)
        {
            return new OperationResult(false, "Database error occurred while updating the user.");
        }
        catch (Exception ex)
        {
            return new OperationResult(false, "An unexpected error occurred.");
        }
    }

    public async Task DeleteUserAsync(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new NullReferenceException("User not found");
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}