namespace Introduction.Services
{
    public interface IJWTAuthenticationService
    {
        string GenerateToken(string userName, string role = "Customer");

        string ValidateToken(string token);
    }
}
