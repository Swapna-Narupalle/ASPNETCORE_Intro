using Introduction.Services;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class BankTransactionsController : ControllerBase
    {
        IAuthenticationService _AuthenticationService;
        public BankTransactionsController(IAuthenticationService authenticationService)
        {
            _AuthenticationService = authenticationService;
        }

        //[api]/[controller]/[actionname]
        //https://localhost:7233/api/BankTransactions/GetCustomerTransactions
        //https://localhost:7233/api/BankTransactions/GetCustomerTransactions
        [HttpPost("GetCustomerTransactions")]
        public IActionResult GetCustomerTransactions([FromHeader(Name = "Authorization")] string token)
        {
            var _message = "Customes can see this transaction";
            return Ok(new { Message = _message });
        }



        //[HttpPost("GetCustomerDepoistHistory")]
        //public IActionResult GetCsutoemrCreditCArdTRansacion([FromBody] CustomerDTO customerDTO)
        //{

        //}



        //[HttpPost("GetCsutoemrCreditCArdTRansacion")]
        //public IActionResult GetCsutoemrCreditCArdTRansacion([FromBody] CustomerDTO customerDTO)
        //{

        //}




    }
}