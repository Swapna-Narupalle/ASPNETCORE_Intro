using Introduction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class BankTransactionsJWTController : ControllerBase
    {
        IJWTAuthenticationService _JWTAuthenticationService;
        public BankTransactionsJWTController(IJWTAuthenticationService jWTauthenticationService)
        {
            _JWTAuthenticationService = jWTauthenticationService;
        }

        //[api]/[controller]/[actionname]
        //https://localhost:7233/api/BankTransactionsJWT/GetCustomerTransactions
        [HttpPost("GetCustomerTransactions")]
        public IActionResult GetCustomerTransactions([FromHeader(Name = "Authorization")] string token)
        {
            var _message = "Customes can see this transaction";
            return Ok(new { Message = _message });
        }


        //Autherization
        //https://localhost:7233/api/BankTransactionsJWT/GetBankLevelTrasactions
        //whether authenticated user having to access the particular resource or not
        [Authorize(Roles = "Customer")]
        [HttpPost("GetBankLevelTrasactions")]
        public IActionResult GetBankLevelTrasactions()
        {
            var _message = "You are the manager so you can check the Bank level transactions";
            return Ok("record success");
        }



    }
}