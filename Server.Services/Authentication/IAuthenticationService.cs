namespace Server.Services.Authentication
{
    public interface IAuthenticationService
    {
        string GenerateJWTToken(string userId);
    }
}