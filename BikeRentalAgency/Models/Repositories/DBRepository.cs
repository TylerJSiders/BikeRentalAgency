using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models.Interfaces;
using BikeRentalAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalAgency.Models.Repositories
{
    public class DBRepository : IDBRepository
    {
        private readonly AgencyDBContext context;
        public DBRepository(AgencyDBContext context)
        {
            this.context = context;
        }

        public Task<Customer> GetCustomerByID(int id)
        {
            var customer = context.Customers.FirstOrDefaultAsync(c => c.ID == id);
            if (customer != null)
                return customer;
            return null;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await context.Customers.ToListAsync();
        }
    }
}
