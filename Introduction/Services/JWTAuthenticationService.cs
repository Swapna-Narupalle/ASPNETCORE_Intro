using Microsoft.IdentityModel.Tokens; // For SymmetricSecurityKey
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;  // For Encoding.UTF8  



namespace Introduction.Services
{
    public class JWTAuthenticationService : IJWTAuthenticationService
    {

        private readonly string _secreat = "madan!12346711@#@@@@@#$%TGFFDERRRavafas";
        private readonly string _issuer = "HDFCBank";
        private readonly string _audiance = "HDFCTellers";

        public string GenerateToken(string userName, string role = "Customer")
        {
            // throw new NotImplementedException();

            //claim:it is a piece of information about the user,,contain Name, Role, email, homeAddress, phoneNumber

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, "madan.patakota@gmail.com"),
                new Claim(ClaimTypes.Role, "Customer"),
                new Claim(ClaimTypes.MobilePhone, "9010244141"),
                new Claim(ClaimTypes.PostalCode, "516175")
            };

            //SymmetricSecuritykey
            var Secreatkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secreat));

            //signingcredensials ---> Securitykey along with HmacSha256 securityAlgorithms
            var signInCreds = new SigningCredentials(Secreatkey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audiance,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signInCreds
              );

            //serialization- converting object----> string, Json, xml,binary
            //deserialization : opposite to serialization

            var finalToken = new JwtSecurityTokenHandler().WriteToken(token);
            return finalToken;
        }

        public string ValidateToken(string token)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
