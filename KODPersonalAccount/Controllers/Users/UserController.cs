using System.Security.Claims;
using KODPersonalAccount.Interfaces.Services.Users;
using KODPersonalAccount.Models.Entity;
using KODPersonalAccount.Models.Strunctures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KODPersonalAccount.Controllers.Users;

[ApiController]
[Route("[controller]")]
public class UserController(IUserAppService userAppService) : Controller
{
    private readonly IUserAppService _userAppService = userAppService;
    
    [Authorize]
    [HttpGet("getMe")]
    public async Task<IActionResult> GetMeAsync()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        User? user = await _userAppService.GetUserByIdAsync(Convert.ToInt64(id));
        if (user == null)
        {
            return NotFound("user not found");
        }

        return Ok(user);
    }
    
    [HttpGet("getUser/{id}")]
    public async Task<IActionResult> GetUserAsync(long id)
    {
        User? user = await _userAppService.GetUserByIdAsync(Convert.ToInt64(id));
        if (user == null)
        {
            return NotFound("user not found");
        }

        return Ok(user);
    }
    
    [HttpGet("getUsers/{page}/{pagesize}")]
    public async Task<IActionResult> GetUserAsync(int page, int pagesize)
    {
        return Ok(await _userAppService.GetAllUsersAsync(page, pagesize));
    }
    
    [HttpGet("getPointsSorted/{page}/{pagesize}")]
    public async Task<IActionResult> GetPointSortedAsync(int page, int pagesize)
    {
        return Ok(await _userAppService.GetSortedByPointsAsync(page, pagesize));
    }
    
    [Authorize]
    [HttpPost("updateName/")]
    public async Task<IActionResult> UpdateNameAsync([FromBody]string newName, [FromBody]bool isLastname)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        return Ok(await _userAppService.UpdateNameAsync(Convert.ToInt64(id), newName, isLastname));
    }
    
    [Authorize]
    [HttpPost("updateName/{userid}")]
    public async Task<IActionResult> UpdateNameAsync(int userid, [FromBody]string newName, [FromBody]bool isLastname)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Админ")
        {
            return Unauthorized("Недоступно.");
        }
        return Ok(await _userAppService.UpdateNameAsync(userid, newName, isLastname));
    }
    
    [Authorize]
    [HttpPost("addPoint/{userid}")]
    public async Task<IActionResult> UpdateNameAsync(int userid, [FromBody]float point)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Админ")
        {
            return Unauthorized("Недоступно.");
        }
        return Ok(await _userAppService.AddScoreToUserAsync(userid, point));
    }
    
    [Authorize]
    [HttpPost("updateTelegramData/")]
    public async Task<IActionResult> UpdateTelegrammDataAsync([FromBody] TelegramUser user)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Convert.ToInt64(id) != user.Id)
        {
            return Unauthorized("Недоступно.");
        }
        
        return Ok(await _userAppService.UpdateTelegramDataAsync(user));
    }
    
    [Authorize]
    [HttpPost("updateTelegramData/{userId}")]
    public async Task<IActionResult> UpdateTelegrammDataAsync(long userId, [FromBody] TelegramUser user)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        if (role != "Админ")
        {
            return Unauthorized("Недоступно.");
        }
        
        return Ok(await _userAppService.UpdateTelegramDataAsync(user));
    }

    [Authorize]
    [HttpDelete("deleteUser/{userid}")]
    public async Task<IActionResult> DeleteUserAsync(long userId)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        if (role != "Админ")
        {
            return Unauthorized("Недоступно.");
        }

        await _userAppService.DeleteUserAsync(userId);
        return Ok();
    }
}