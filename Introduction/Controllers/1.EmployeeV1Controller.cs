using Microsoft.AspNetCore.Mvc;

namespace Introduction
{


    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV1WithOutDIController : ControllerBase    // controller is a HighLigher Level Module. its giving the response to the clinet
    {

        private EmployeeReposiotry _repo;
        public EmployeeV1WithOutDIController()
        {
            _repo = new EmployeeReposiotry();  // Here i am trying to create the instance of the class
        }


        //http://localhost:5171/api/EmployeeV1WithOutDI/GetAllElmployees
        [HttpGet]
        [Route("GetAllElmployees")]
        public async Task<IActionResult> GetAllEmp()
        {
            //_repo =  new EmployeeReposiotry();
            await Task.Delay(1000);
            var result = _repo._employees();
            return Ok(result);
        }

    }


    //Reposiroy
    public class EmployeeReposiotry
    {

        public EmployeeReposiotry()
        {

        }


        public List<Employee> _employees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Department = "IT" },
                new Employee { Id = 2, Name = "Sara", Department = "HR" }
            };
        }
    }


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }









}