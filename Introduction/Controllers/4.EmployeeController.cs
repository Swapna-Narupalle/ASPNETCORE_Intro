using Introduction.Controllers.Employee_2;
using Microsoft.AspNetCore.Mvc;


//put method background


// 1 - do tupdate 

namespace Introduction.Controllers.Employees_4
{
    [ApiController]
    [Route("api/[Controller]")]
    //put | patch | Delte

    //what is accesss modifier? public | internal
    public class EmployeeV4Controller : ControllerBase
    {
        // you cannot add , remove , update any operations you just readonly
        private static List<Employee> _dbstore = new List<Employee>()
        {
            new Employee(){ EmpId = 1 , EmpName = "John" , EmpLocation = "UK" , EmpAddress = "Xyz"},
            new Employee(){ EmpId = 2 , EmpName = "Peter" , EmpLocation = "US" , EmpAddress = "abc"},
            new Employee(){ EmpId = 3 , EmpName = "Sam" , EmpLocation = "India" , EmpAddress = "def"}
        };


        ///put method to update the records 
        /// Id based on the we are goint to update the records
        /// you need to send the body
        /// 

        //1 ---> name , location , address

        //https://localhost:7233/api/EmployeeV4/updateEmployee/1

        [HttpPut]
        [Route("updateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int Id, [FromBody] EmployeeDTO empdto)
        {
            await Task.Delay(2000);

            var employee = _dbstore.Where(x => x.EmpId == Id).First();  // you will get the all the reacords where are match to id 

            if (employee != null)
            {
                // do the update
                employee.EmpName = empdto.Name;
                employee.EmpLocation = empdto.Location;
                employee.EmpAddress = empdto.Address;

                return Ok($"Record is updated with the {empdto.Name} ......");

            }
            else
            {
                // send the bad request
                return BadRequest("Your details are not availble . pLease check again ");
            }
            //Output body-row-json
            //{
            //   "name": "Swapna",
            //    "location":"Mydukur",
            //     "Address":"Bangalore"
            //}
        }




        //patch 

        //partial update i just want to update 1 or 2 columns 3 or 

        //Patching works  | partial works | half -half works
        //https://localhost:7233/api/EmployeeV4/UpdateEmployeeWithFewData/1

        [HttpPatch]
        [Route("UpdateEmployeeWithFewData/{Id}")]
        public async Task<IActionResult> UpdateEmployeeWithFewData([FromRoute] int Id, [FromBody] EmployeeDTO empdto)
        {
            await Task.Delay(2000);

            var employee = _dbstore.Where(x => x.EmpId == Id).FirstOrDefault();  // you will get the all the reacords where are match to id 
            //Single and SingleOrDefault

            if (employee != null)
            {
                // do the update
                employee.EmpName = empdto.Name;
                //employee.EmpLocation = empdto.Location;
                //employee.EmpAddress = empdto.Address;

                return Ok($"Record is updated with tthe {empdto.Name} ......");

            }
            else
            {
                // send the bad request
                return BadRequest("Your details are not availble . pLease check again ");
            }
            //Output body-row-json
            //{
            //   "name": "Swapna"

            //}
        }



        //https://localhost:7233/api/EmployeeV4/DeleteEmployee/1

        [HttpDelete]
        [Route("DeleteEmployee/{Id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int Id, [FromBody] EmployeeDTO employeedto)
        {
            await Task.Delay(2000);   
       
            var employee = _dbstore.Where(x => x.EmpId == Id && employeedto.Name == "John").FirstOrDefault();  // you will get the all the reacords where are match to id 

            if (employee != null)
            {
                _dbstore.Remove(employee);  // expcepted the exceptoin

                return Ok($"Record is updated with tthe {employee.EmpName} ......");

            }
            else
            {
                // send the bad request
                return BadRequest("Your details are not availble . pLease check again ");
            }
        }

        //Output body-row-json
        //{
        //   "name": "John"
        //}

}









    //Data Transfer Object
    public class EmployeeDTO
    {
        public string Name { get; set; }       
        public string? Location { get; set; }
        public string? Address { get; set; }

    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLocation { get; set; }
        public string EmpAddress { get; set; }
    }
}
