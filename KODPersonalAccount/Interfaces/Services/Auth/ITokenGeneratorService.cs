namespace KODPersonalAccount.Applications.Interfaces.Services;

public interface ITokenGeneratorService
{
    public string GenerateAccessToken(string tgId, string role);
    public string GenerateRefreshToken(string tgId);
}
