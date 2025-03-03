using System.Security.Claims;
using KODPersonalAccount.Applications.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KODPersonalAccount.Applications.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("telegam/")]
    public async Task<IActionResult> AuthAsync([FromBody] string initData)
    {
        var tokens = await _authService.AuthAsync(initData);
        if (tokens == null)
        {
            return Unauthorized("Telegram string is not correct");
        }

        return Ok(tokens);
    }

    [HttpPost("refresh/")]
    public async Task<IActionResult> RefreshToken([FromBody] string token)
    {
        var tokens = await _authService.RefreshTokenAsync(token);
        if (tokens == null)
        {
            return Unauthorized("Token is not active");
        }

        return Ok(tokens);
    }
    
    [Authorize]
    [HttpGet("authTest")]
    public IActionResult AuthTest()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        return Ok(id + "  user.    " + role + "  role.");
    }
}
