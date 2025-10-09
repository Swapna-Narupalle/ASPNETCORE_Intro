using Introduction.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    [RequireDomainEmailAttribute]
    public class ReportsController : ControllerBase
    {
        //https://localhost:7233/api/Reports/daily
        [HttpGet("daily")]
        public IActionResult GetDaily([FromHeader(Name = "email")] string email)
        {
            return Ok(new { Message = "Daily report generated.", Email = email });
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthly([FromHeader(Name = "email")] string email)
        {
            return Ok(new { Message = "Monthly report generated.", Email = email });
        }


        [HttpGet("Yearly")]
        public IActionResult GetYearly([FromHeader(Name = "email")] string email)
        {
            return Ok(new { Message = "Yearly report generated.", Email = email });
        }
    }
}