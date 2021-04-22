using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgency.Models.Interfaces
{
    public interface IDBRepository
    {
        public Task<List<Customer>> GetCustomers();
        public Task<Customer> GetCustomerByID(int id);
    }
}
