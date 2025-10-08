
using Introduction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        IAuthenticationService _AuthenticationService;
        IJWTAuthenticationService _JWTAuthenticationService;
        public LoginController(IAuthenticationService authenticationService, IJWTAuthenticationService jWTAuthentication)
        {
            _AuthenticationService = authenticationService;
            _JWTAuthenticationService = jWTAuthentication;
        }

        //[api]/[controller]/[actionname]
        //https://localhost:7233/api/Login/LoginUser
        [HttpPost("LoginUser")]
        public IActionResult LoginUser([FromBody] CustomerDTO customerDTO)
        {
            List<CustomerDTO> cus = new List<CustomerDTO>();

            if (customerDTO.Username == "Madan" && customerDTO.Password == "madan!123")
            {
                //i need to give the token
                string token = _JWTAuthenticationService.GenerateToken(customerDTO.Username, "Customer");
                return Ok(new { Token = token });
            }
            else if (string.IsNullOrEmpty(customerDTO.Username) || string.IsNullOrEmpty(customerDTO.Password))
            {
                return BadRequest("Kindly do't give your values either null or empty . Please give the username and password correctly");
            }
            else
            {
                return Unauthorized("Invalid Username and password");
            }
        }
    }


    public class CustomerDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}