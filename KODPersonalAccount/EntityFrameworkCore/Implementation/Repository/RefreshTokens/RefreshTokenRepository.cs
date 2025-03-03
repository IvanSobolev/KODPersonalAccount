using KODPersonalAccount.Applications.EntityFrameworkCore;
using KODPersonalAccount.Applications.Interfaces.Repository;
using KODPersonalAccount.Applications.Models.Entity;
using KODPersonalAccount.Applications.Models.Strunctures;
using Microsoft.EntityFrameworkCore;

namespace KODPersonalAccount.Applications;

public class RefreshTokenRepository(DataContext context) : IRefreshTokenRepository
{
    private readonly DataContext _context = context;

    public async Task<User?> GetUserByTokenAsync(string token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == token);
        if (user == null)
        {
            return null;
        }

        return user;
    }

    public async Task<OperationResult> ReplaceEmptyToken(long id, string token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return new OperationResult(false, "User not found");
        }

        if (user.RefreshToken != "")
        {
            return new OperationResult(false, "User token is not empty");
        }
        
        try
        {
            user.RefreshToken = token;
            user.ExpiresToken = DateTime.UtcNow;
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

    public async Task<OperationResult> UpdateTokenAsync(string oldToken, string newToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == oldToken);
        if (user == null)
        {
            return new OperationResult(false, "User not found");
        }

        if (user.ExpiresToken.AddDays(1) < DateTime.UtcNow)
        {
            return new OperationResult(false, "Old token is not correct");
        }
        
        try
        {
            user.RefreshToken = newToken;
            user.ExpiresToken = DateTime.UtcNow;
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

    public async Task DeleteActiveTokenByIdAsync(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
