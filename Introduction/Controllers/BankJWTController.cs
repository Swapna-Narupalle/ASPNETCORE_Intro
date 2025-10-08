using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class BankJWTController : ControllerBase
    {
        [HttpGet("GetResults")]
        public IActionResult GetResults()
        {
            return Ok("Success");
        }
    }
}