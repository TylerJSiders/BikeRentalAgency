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
    public class CustomersController : ControllerBase
    {
        private IDBRepository Repository;

        public CustomersController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var Customers = await Repository.GetCustomers();
            if (Customers != null)
                return Customers;
            return BadRequest();
        }

        // GET: api/Customers/5
        [HttpGet("GetCustomerByID/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerByID(int id)
        {
            var customer = await Repository.GetCustomerByID(id);

            if (customer == null)
            {
                return NoContent();
            }

            return customer;
        }

        [HttpGet("GetCustomersByLastName/{LastName}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByLastName(string LastName)
        {
            var customer = await Repository.GetCustomersByLastName(LastName);
            if (customer == null)
            {
                return NoContent();
            }

            return customer;
        }

        //// PUT: api/Customers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, Customer customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            if (!Repository.CustomerExists(id))
                return NoContent();

            var customerchanges = await Repository.UpdateCustomer(customer);
            return customerchanges;            
        }

        //// POST: api/Customers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (Repository.CustomerExistsByEmail(customer.Email))
                return BadRequest($"User with email {customer.Email} already exists.");
            var customerAdded = await Repository.AddCustomer(customer);
            return customerAdded;

            //return CreatedAtAction("GetCustomerByID", customerAdded, customer);
        }

        //// DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await Repository.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerDeleted = await Repository.DeleteCustomer(customer.ID);
            return customerDeleted;
        }
    }
}
