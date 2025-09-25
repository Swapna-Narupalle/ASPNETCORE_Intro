using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class HttpContextDemoController : ControllerBase
    {


        //[HttpPost]
        //[Route("ShowContext{Id}")]

        /// <summary>
        ///  This is method is about to create the User
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="age"></param>
        /// <param name="location"></param>
        /// <param name=""></param>
        /// <returns></returns>

        //https://localhost:7233/api/HttpContextDemo/ShowContext/1?age=20&location=hye
        [HttpPost("ShowContext/{Id}")]
        public IActionResult ShowContext(
            int Id,   //Router param
            [FromQuery] int age,  //Query param
            [FromQuery] string location,  //Query param
            [FromBody] UserDTO user,   //Body
            [FromHeader(Name = "Custom-header")] string customheader  //Header
            )
        {

            var context = HttpContext;

            var httpContextHeaders = HttpContext.Request.Headers;
            var httpContextBody = HttpContext.Request.Body;

            var httpContextPath = HttpContext.Request.Path;


            HttpContext.Response.Headers.Append("X-demo-Response", "This came from server");
            HttpContext.Response.Headers.Append("X-demo-statusCode", "Successfull");



            return Ok(new
            {
                RouterID = Id,
                QueryAge = age,
                QueryLocation = location,
                UserFromBody = user,
                Message = "✅ Data received successfully from client",
            });


        }





    }

    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}