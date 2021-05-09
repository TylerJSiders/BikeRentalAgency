using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRentalAgency.Models;
using BikeRentalAgency.Models.Interfaces;
using BikeRentalAgency.Models.Repositories;
using BikeRentalLibrary;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IDBRepository Repository;

        public EmployeesController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await Repository.GetEmployees();
            return employees;
        }

        [HttpGet("GetEmployeeByID/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {
            var employee = await Repository.GetEmployeeByID(id);
            if (employee == null)
                return NotFound();
            return employee;
        }



        //    // PUT: api/Employees/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateEmployee/{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            if (!Repository.EmployeeExistsByID(id))
                return NoContent();
            var EmployeeChanges = await Repository.UpdateEmployee(employee);
            return EmployeeChanges;
        }

        //    // POST: api/Employees
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (!Repository.RentalShopExists(employee.ShopID))
                return StatusCode(12, $"Shop with Shop ID {employee.ShopID} does not exist.");
            return await Repository.AddEmployee(employee);
            //var createdEmployee = await Repository.AddEmployee(employee);
            //return StatusCode(201, createdEmployee);
            ////return CreatedAtAction("GetEmployee", new { id = employee.ID }, employee);
        }

        //    // DELETE: api/Employees/5
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            if (!Repository.EmployeeExistsByID(id))
                return NoContent();
            var employeeDeleted = await Repository.DeleteEmployee(id);
            return employeeDeleted;
        }

    }
}
