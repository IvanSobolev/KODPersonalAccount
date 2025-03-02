using System.Security.Claims;
using KODPersonalAccount.Interfaces.Services.Users;
using KODPersonalAccount.Models.DTO.Users;
using KODPersonalAccount.Models.Entity;
using KODPersonalAccount.Models.Strunctures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KODPersonalAccount.Controllers.Users;

[ApiController]
[Route("users")]
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
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetUserAsync(long id)
    {
        User? user = await _userAppService.GetUserByIdAsync(Convert.ToInt64(id));
        if (user == null)
        {
            return NotFound("user not found");
        }

        return Ok(user);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUserAsync(int page, int pagesize)
    {
        return Ok(await _userAppService.GetAllUsersAsync(page, pagesize));
    }
    
    [HttpGet("getPoints")]
    public async Task<IActionResult> GetPointSortedAsync(int page, int pagesize)
    {
        return Ok(await _userAppService.GetSortedByPointsAsync(page, pagesize));
    }
    
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateNameAsync([FromBody]UserUpdateDto input)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        return Ok(await _userAppService.UpdateNameAsync(Convert.ToInt64(id), input.NewName, input.IsLastName));
    }
    
    [Authorize]
    [HttpPut("{userid:long}")]
    public async Task<IActionResult> UpdateNameAsync(long userid, [FromBody]UserUpdateDto input)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        if (role != "Админ")
        {
            return Unauthorized("Недоступно.");
        }
        return Ok(await _userAppService.UpdateNameAsync(userid, input.NewName, input.IsLastName));
    }
    
    [Authorize]
    [HttpPost("addPoint/{userid:long}")]
    public async Task<IActionResult> UpdateNameAsync(long userid, [FromBody]float point)
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
    public async Task<IActionResult> UpdateTelegrammDataAsync([FromBody]TelegramUser user)
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Convert.ToInt64(id) != user.Id)
        {
            return Unauthorized("Недоступно.");
        }
        
        return Ok(await _userAppService.UpdateTelegramDataAsync(user));
    }
    
    [Authorize]
    [HttpPut("updateTelegramData/{userId:long}")]
    public async Task<IActionResult> UpdateTelegrammDataAsync(long userId, [FromBody]TelegramUser user)
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        if (role != "Админ")
        {
            return Unauthorized("Недоступно.");
        }
        
        return Ok(await _userAppService.UpdateTelegramDataAsync(user));
    }

    [Authorize]
    [HttpDelete("{userid:long}")]
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