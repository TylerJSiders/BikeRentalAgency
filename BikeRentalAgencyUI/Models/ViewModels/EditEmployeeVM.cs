using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalLibrary;

namespace BikeRentalAgencyUI.Models.ViewModels
{
    public class EditEmployeeVM
    {
        public Employee employee;
        public List<RentalShop> rentalShops;

        public EditEmployeeVM()
        {

        }


        public EditEmployeeVM(Employee employee, List<RentalShop> rentalShops)
        {
            this.employee = employee;
            this.rentalShops = rentalShops;
        }
    }
}
