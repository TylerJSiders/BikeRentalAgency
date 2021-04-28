using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;


namespace BikeRentalAgencyUI.Models.Interfaces
{
    public interface IBikeRentalRepo
    {
        //Employee Methods
        public Task<bool> AddEmployee(Employee employee);
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeByID(int id);
        public Task<bool> UpdateEmployee(Employee EmployeeChanges);
        public Task<bool> DeleteEmployee(int id);

    }
}
