using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Introduction.Controllers.Employee_2
{


    [ApiController]
    [Route("api/[Controller]")]

    public class EmployeeV2Controller : ControllerBase
    {
        public EmployeeV2Controller() { }

        //Route paramters
        //link:https://localhost:7233/api/EmployeeV2/GetEmployeesList/1

        [HttpGet]   // if the request is data fetch then desing with httpget
        [Route("GetEmployeesList/{id:int}")]

        public async Task<IActionResult> GetEmployeesList(int Id)
        {

            var employeesList = await GetEmployees();

            var result = employeesList.Where(x => x.EmpId == Id);
            if (!result.Any())
            {
                return NotFound($"No employees found with the name of {Id}");  // 404 Not found
            }
            else
            {
                return Ok(result.First());
            }

            //return Ok(new List<string> { "Swapna", "Divya" });  // we get 200 it is success code.json
        }







        //link:https://localhost:7233/api/EmployeeV2/GetEmployeesListByLocatinAndSalary/New%20York/28000

        [HttpGet]   // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalary/{location}/{salary:double}")]

        public async Task<IActionResult> GetEmployeesListByLocatinAndSalary(string location, double salary)
        {

            var employeesList = await GetEmployees();

            var result = employeesList.Where(x => x.EmpLocation == location && x.EmpSalary > salary);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {location} - {salary}");  // 404 Not found
            }
            else
            {
                return Ok(result.First());
            }

            //return Ok(new List<string> { "Swapna", "Divya" });  // we get 200 it is success code.json
        }





        //link:https://localhost:7233/api/EmployeeV2/GetEmployeesListByLocatinAndSalaryWithQuery?locationName=New%20York
        [HttpGet]   // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalaryWithQuery")]

        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithQuery(string locationName)
        {

            var employeesList = await GetEmployees();

            var result = employeesList.Where(x => x.EmpLocation == locationName);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location {locationName} - {locationName}");  // 404 Not found
            }
            else
            {
                return Ok(result.First());
            }

            //return Ok(new List<string> { "Swapna", "Divya" });  // we get 200 it is success code.json
        }





        ////https://localhost:7233/api/EmployeeV2/GetEmployeesListByLocatinAndSalaryWithQuery?location=New%20York

        //[HttpGet]  // if the request is data fetch then desing with httpget
        //[Route("GetEmployeesListByLocatinAndSalaryWithQuery")]
        //public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithQuery([FromQuery(Name = "location")] string locationName)
        //{
        //    var employeesList = await GetEmployees();  // given the resoponse to the guy who asked the data
        //    var result = employeesList.Where(x => x.EmpLocation == locationName);
        //    if (!result.Any())
        //    {
        //        return NotFound($"No employees found with salary and location {locationName} - {locationName} ");   // 404 Not found
        //    }
        //    else
        //    {
        //        return Ok(result);
        //    }
        //    //  return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        //}






        //link:http://localhost:5171/api/GetEmployeesListByLocatinAndSalaryWithMultiQueryParams?empname=John&location=New%20York&salary=28000

        [HttpGet]   // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalaryWithMultiQueryParams")]

        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithMultiQueryParams(
            [FromQuery(Name = "EmpName")] string empName,
            [FromQuery(Name = "location")] string locationName,
            [FromQuery(Name = "salary")] double salary)
        {

            var employeesList = await GetEmployees();

            var result = employeesList.Where(x => x.EmpLocation == locationName && x.EmpSalary > salary && x.EmpName == empName);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location and empName {locationName} - {salary} - {empName}");  // 404 Not found
            }
            else
            {
                return Ok(result);
            }

            //return Ok(new List<string> { "Swapna", "Divya" });  // we get 200 it is success code.json
        }




        //DTO
        //link:http://localhost:5171/api/GetEmployeesListByLocatinAndSalaryWithMultiQueryParamsWithDTO?empname=John&location=New%20York&salary=28000

        [HttpGet]   // if the request is data fetch then desing with httpget
        [Route("GetEmployeesListByLocatinAndSalaryWithMultiQueryParamsWithDTO")]

        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithMultiQueryParamsWithDTO(
            [FromQuery] EmployeeDTO employee)
        {

            var employeesList = await GetEmployees();

            var result = employeesList.Where(x => x.EmpLocation == employee.Location && x.EmpSalary > employee.Salary && x.EmpName == employee.EmpName);
            if (!result.Any())
            {
                return NotFound($"No employees found with salary and location and empName {employee.Location} - {employee.Salary} - {employee.EmpName}");  // 404 Not found
            }
            else
            {
                return Ok(result);
            }

            //return Ok(new List<string> { "Swapna", "Divya" });  // we get 200 it is success code.json
        }










        private async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(3000);
            return store();


        }

        private List<Employee> store()
        {
            return new List<Employee>()
            {
                    new Employee() { EmpId = 1, EmpName = "Michel", EmpLocation = "New York", EmpSalary = 20000.89 },
                    new Employee() { EmpId = 2, EmpName = "Sarah",  EmpLocation = "London",   EmpSalary = 25000.50 },
                    new Employee() { EmpId = 3, EmpName = "Ravi",   EmpLocation = "Bangalore",EmpSalary = 18000.00 },
                    new Employee() { EmpId = 4, EmpName = "Emily",  EmpLocation = "New York", EmpSalary = 30000.75 },
                    new Employee() { EmpId = 5, EmpName = "John",   EmpLocation = "New York", EmpSalary = 22000.40 }
            };
        }

        public class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpLocation { get; set; }
            public double EmpSalary { get; set; }
        }


        public class EmployeeDTO
        {
            public string EmpName { get; set; }
            public string Location { get; set; }
            public double Salary { get; set; }

        }




    }
}
