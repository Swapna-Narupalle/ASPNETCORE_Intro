using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{

    //attribute - To communicate to the ASP.NET Core and this class is useful to build the APIs
    [ApiController]

    //Route attribute that defines the base URL path for the controller
    //controller its kind of placeholder that automatically use the class name
    [Route("api/[controller]")]

    //studentController Using this i can define the ApIs
    public class StudentsController : ControllerBase
    {
        [HttpGet]  //used to return(get) the data
        [Route("GetStuName")]

        //public string GetStuName()
        //{
        //    return "Swapna Reddy";
        //}

        //bad ways: It shows 500 and lengthy message in preview

        //public dynamic GetStuName()
        //{
        //    throw new Exception("something went wrong");
        //}

        //public dynamic GetStuName()
        //{
        //    string empname = null;
        //    return empname.ToUpper();
        //}

        //good way : It shows 404 in angular browser
        public IActionResult GetStuName()
        {
            //string empname = null;
            string empname = "Swapna Reddy";
            if (empname == null)
            {
                return NotFound(new { Message = "Emp[loyee not found" });
            }
            return Ok(new { Message = "Employee is Swapna Reddy" });
        }

        [HttpGet]  //used to return(get) the data
        [Route("GetStuCount")]

        public int GetStuCount()
        {
            return 50;
        }
    }
}


//https://localhost:7233/api/Students/GetStuName
//https://localhost:7233/api/Students/GetStuCount