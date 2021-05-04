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

        //Rental Shop Methods
        public Task<bool> AddRentalShop(RentalShop rentalShop);
        public Task<List<RentalShop>> GetRentalShops();
        public Task<RentalShop> GetRentalShopByID(int id);
        public Task<bool> DeleteRentalShop(int id);
        public Task<bool> UpdateRentalShop(RentalShop ShopChanges);

        // Bike Methods
        public Task<bool> AddBike(Bike bike);
        public Task<List<Bike>> GetBikes();
        public Task<Bike> GetBikeByID(int id);
        public Task<bool> DeleteBike(int id);
        public Task<bool> UpdateBike(Bike bike);
        public bool BikeExists(int id);

        //Reservations
        public Task<bool> AddReservation(Reservation reservation);
        public Task<List<Reservation>> GetReservations();
        public Task<Reservation> GetReservationByID(int id);
        //public Task<Reservation> GetReservationByName(string lastName);
        public Task<bool> DeleteReservation(int id);
        public Task<bool> UpdateReservation(Reservation reservation);
    }
}
