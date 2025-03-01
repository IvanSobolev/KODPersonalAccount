using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KODPersonalAccount.Configuration;
using KODPersonalAccount.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace KODPersonalAccount.Services;

public class TokenGeneratorService(JwtSettings jwtSettings) : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings = jwtSettings;

    public string GenerateAccessToken(string tgId, string role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, tgId),
            new Claim(ClaimTypes.Role, role),
        };

        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public string GenerateRefreshToken(string tgId)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, tgId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}