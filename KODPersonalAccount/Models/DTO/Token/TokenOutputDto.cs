namespace KODPersonalAccount.Applications.Models.DTO;

public class TokenOutputDto(string accessToken, string refreshToken)
{
    public string AccessToken { get; set; } = accessToken;
    public string RefreshToken { get; set; } = refreshToken;
}
