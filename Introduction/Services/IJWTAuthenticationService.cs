using System.Security.Claims;

namespace Introduction.Services
{
    public interface IJWTAuthenticationService
    {
        string GenerateToken(string userName, string role = "Customer");

        ClaimsPrincipal ValidateToken(string token);
    }
}
