using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.Employee_1
{
    //link:https://localhost:7233/api/EmployeeV1/GetEmployeesList

    //asp.netCore server | kestral things that this class able to create the endpoints 


    //controllerbase is a class which is useful for to prepare the status to responses 

    [ApiController]
    [Route("api/[Controller]")]

    public class EmployeeV1Controller : ControllerBase
    {
        public EmployeeV1Controller() { }

        //[HttpGet]   // if the request is data fetch then desing with httpget
        //[Route("GetEmployeesList")]

        //public async Task<IActionResult> GetEmployeesList()
        //{
        //    await Task.Delay(4000);    // given the resoponse to the guy who asked the data
        //    return Ok(new List<string> { "Swapna", "Divya" });  //we get 200 it is success code.json
        //}



        [HttpGet]   // if the request is data fetch then desing with httpget
        [Route("GetEmployeesList")]

        public async Task<IActionResult> GetEmployeesList()
        {
            string EmpName = "Swapna";
            var employeesList = await GetEmployees();

            var count = employeesList.Where(x => x == EmpName).Count();
            if (count == 0)
            {
                return NotFound($"No employees found with the name of {EmpName}");  // 404 Not found
            }

            return Ok(new List<string> { "Swapna", "Divya" });  // we get 200 it is success code.json
        }

        private async Task<List<string>> GetEmployees()
        {
            await Task.Delay(3000);
            return store();


        }

        private List<string> store()
        {
            return new List<string> { "Swapna", "Divya", "Sandya" };
        }




    }
}
