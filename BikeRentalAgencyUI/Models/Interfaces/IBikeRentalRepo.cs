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

        //Location Methods
        public Task<bool> AddRentalShop(RentalShop rentalShop);
        public Task<List<RentalShop>> GetRentalShops();
        public Task<RentalShop> GetRentalShopByID(int id);
        public Task<bool> DeleteRentalShop(int id);
        public Task<bool> UpdateRentalShop(RentalShop ShopChanges);

        //Reservation Methods
        public Task<bool> AddReservation(Reservation reservation);
        public Task<List<Reservation>> GetReservations();
        public Task<Reservation> GetReservationByID(int id);
        public Task<bool> UpdateReservation(Reservation reservationChanges);
        public Task<bool> DeleteReservation(int id);

        //Bike Methods
        public Task<bool> AddBike(Bike bike);
        public Task<List<Bike>> GetBikes();
        public Task<Bike> GetBikeByID(int id);
        public Task<bool> UpdateBike(Bike bikeChanges);
        public Task<bool> DeleteBike(int id);
        // Customer Methods
        public Task<bool> AddCustomer(Customer customer);
        public Task<List<Customer>> GetCustomers();
        public Task<Customer> GetCustomerByID(int id);
        public Task<bool> UpdateCustomer(Customer customerChanges);
        public Task<bool> DeleteCustomer(int id);

        //Admin Methods
        public Task<bool> AddAdmin(AdminLogin adminLogin);
        public Task<List<AdminLogin>> GetAdmins();
        public Task<AdminLogin> GetAdminByID(int id);
        public Task<bool> DeleteAdmin(int id);
        public Task<bool> UpdateAdmin(AdminLogin adminChanges);

    }
}
