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


        //customer Methods
        public async Task<Customer> GetCustomerByID(int id)
        {
            var customer = await context.Customers.FindAsync(id);
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
        //Employee Methods
        public async Task<Employee> AddEmployee(Employee employee)
        {
            //TODO Add Employee to rental Shop list
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            var EmployeeAdded = await context.Employees.OrderByDescending(e => e.ID).FirstOrDefaultAsync();
            return EmployeeAdded;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeByID(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
                return null;
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee EmployeeChanges)
        {
            var employee = context.Employees.Attach(EmployeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return await context.Employees.FindAsync(EmployeeChanges.ID);
        }


        public bool EmployeeExistsByEmail(string email)
        {
            if (context.Employees.Any(c => c.Email == email))
                return true;
            return false;
        }

        public bool EmployeeExistsByID(int id)
        {
            if (context.Employees.Any(e => e.ID == id))
                return true;
            return false;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
        //Special Feature Methods
        public async Task<SpecialFeature> CreateSpecialFeature(SpecialFeature feature)
        {
            context.SpecialFeatures.Add(feature);
            await context.SaveChangesAsync();
            var SpecialFeatureAdded = await context.SpecialFeatures.OrderByDescending(f => f.ID).FirstOrDefaultAsync();
            return SpecialFeatureAdded;
        }
        public bool SpecialFeatureExists(int id)
        {
            return context.SpecialFeatures.Any(f => f.ID == id);
        }
        public async Task<SpecialFeature> DeleteSpecialFeature(int id)
        {
            var specialFeature = await context.SpecialFeatures.FindAsync(id);
            context.SpecialFeatures.Remove(specialFeature);
            await context.SaveChangesAsync();
            return specialFeature;
        }

        public async Task<List<SpecialFeature>> GetSpecialFeatures()
        {
            return await context.SpecialFeatures.ToListAsync();
        }

        public async Task<SpecialFeature> UpdateSpecialFeature(SpecialFeature FeatureUpdate)
        {
            var feature = context.SpecialFeatures.Attach(FeatureUpdate);
            feature.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return await context.SpecialFeatures.FindAsync(FeatureUpdate.ID);
        }

        public async Task<SpecialFeature> GetSpecialFeatureByID(int id)
        {
            return await context.SpecialFeatures.FindAsync(id);
        }

        public async Task<RentalShop> AddRentalShop(RentalShop rentalShop)
        {
            context.Shops.Add(rentalShop);
            await context.SaveChangesAsync();
            var RentalShop = await context.Shops.OrderByDescending(s => s.ID).FirstOrDefaultAsync();
            return RentalShop;
        }
        public async Task<List<RentalShop>> GetRentalShops()
        {
            return await context.Shops.ToListAsync();
        }
        public async Task<RentalShop> GetRentalShopByID(int id)
        {
            return await context.Shops.FindAsync(id);
        }
        public bool RentalShopExists(int id)
        {
            return context.Shops.Any(s => s.ID == id);
        }

        public async Task<RentalShop> DeleteRentalShop(int id)
        {
            var ShopToDelete = await GetRentalShopByID(id);
            context.Shops.Remove(ShopToDelete);
            await context.SaveChangesAsync();
            return ShopToDelete;
        }

        public async Task<RentalShop> UpdateRentalShop(RentalShop ShopChanges)
        {
            var Shop = context.Shops.Attach(ShopChanges);
            Shop.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return await context.Shops.FindAsync(ShopChanges.ID);
        }
    }
}
