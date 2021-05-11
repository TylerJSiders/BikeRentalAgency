using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;

namespace BikeRentalAgencyUI.Models.ViewModels
{
    public class EmployeeIndexVM
    {
        public List<Employee> employees;
        public List<RentalShop> rentalShops;

        public EmployeeIndexVM(List<Employee> employees, List<RentalShop> rentalShops)
        {
            this.employees = employees;
            this.rentalShops = rentalShops;
        }
    }
}
