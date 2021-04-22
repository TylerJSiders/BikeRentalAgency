using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models.Interfaces;
using BikeRentalAgency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalAgency.Models.Repositories
{
    public class DBRepository : IDBRepository
    {
        private readonly AgencyDBContext context;
        public DBRepository(AgencyDBContext context)
        {
            this.context = context;
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(c => c.ID == id);
            if (customer != null)
                return customer;
            return null;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByLastName(string name)
        {
            bool LastNameExists = context.Customers.Where(c => c.LastName == name).Any();
            if (LastNameExists)
                return await context.Customers.Where(c => c.LastName == name).ToListAsync();
            return null;
        }

        public async Task<Customer> UpdateCustomer(Customer CustomerChanges)
        {
            
            var customer = context.Customers.Attach(CustomerChanges);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return await context.Customers.FindAsync(CustomerChanges.ID);
        }

        public bool CustomerExists(int id)
        {
            if (context.Customers.Any(c => c.ID == id))
                return true;
            return false;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            var customerAdded = await context.Customers.OrderByDescending(c => c.ID).FirstOrDefaultAsync();
            return customerAdded;
        }


        public bool CustomerExistsByEmail(string email)
        {
            if (context.Customers.Any(c => c.Email == email))
                return true;
            return false;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return customer;
        }
    }
}
