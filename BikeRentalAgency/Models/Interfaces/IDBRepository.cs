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
        public Task<Employee> AddEmployee(Employee employee);
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeByID(int id);
        public Task<Employee> UpdateEmployee(Employee EmployeeChanges);
        public bool EmployeeExistsByEmail(string email);
        public bool EmployeeExistsByID(int id);
        public Task<Employee> DeleteEmployee(int id);
        public Task<SpecialFeature> CreateSpecialFeature(SpecialFeature feature);
        public bool SpecialFeatureExists(int id);
        public Task<SpecialFeature> DeleteSpecialFeature(int id);
        public Task<List<SpecialFeature>> GetSpecialFeatures();
        public Task<SpecialFeature> GetSpecialFeatureByID(int id);
        public Task<SpecialFeature> UpdateSpecialFeature(SpecialFeature FeatureUpdate);
        //Rental Shop Methods
        public Task<RentalShop> AddRentalShop(RentalShop rentalShop);
        public Task<List<RentalShop>> GetRentalShops();
        public Task<RentalShop> GetRentalShopByID(int id);
        public bool RentalShopExists(int id);
        public Task<RentalShop> DeleteRentalShop(int id);
        public Task<RentalShop> UpdateRentalShop(RentalShop ShopChanges);
    }
}
