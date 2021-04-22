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
        public Task<List<Customer>> GetCustomersByLastName(string name);
        public Task<Customer> UpdateCustomer(Customer CustomerChanges);
        public bool CustomerExists(int id);
        public Task<Customer> AddCustomer(Customer customer);
        public bool CustomerExistsByEmail(string email);
        public Task<Customer> DeleteCustomer(int id);
        
    }
}
