using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace BikeRentalAgencyUI.Models.Repositories
{
    public class BikeRentalRepo : IBikeRentalRepo
    {
        private string BaseURL = "https://localhost:44334/api";
        public async Task<bool> AddEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PostAsJsonAsync("api/Employees", employee);
                return res.IsSuccessStatusCode;
            }
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.DeleteAsync($"api/Employees/DeleteEmployee/{id}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<Employee> GetEmployeeByID(int id)
        {
            Employee employee = new Employee();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"api/Employees/GetEmployeeByID/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    employee = JsonConvert.DeserializeObject<Employee>(response);
                }
            }
            return employee;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Employees");
                
                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    employees = JsonConvert.DeserializeObject<List<Employee>>(response);
                }
                return employees;
            }
        }
        public async Task<bool> UpdateEmployee(Employee EmployeeChanges)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PutAsJsonAsync($"api/Employees/{EmployeeChanges.ID}", EmployeeChanges);
                return res.IsSuccessStatusCode;
            }
        }
      
        public async Task<bool> AddRentalShop(RentalShop rentalShop)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PostAsJsonAsync("api/RentalShops", rentalShop);
                return res.IsSuccessStatusCode;
            }
        }
        public async Task<RentalShop> GetRentalShopByID(int id)
        {
            RentalShop rentalShop = new RentalShop();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"api/RentalShops/GetRentalShopByID/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    rentalShop = JsonConvert.DeserializeObject<RentalShop>(response);
                }
            }
            return rentalShop;
        }
        public async Task<List<RentalShop>> GetRentalShops()
        {
            List<RentalShop> rentalShops = new List<RentalShop>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/RentalShops");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    rentalShops = JsonConvert.DeserializeObject<List<RentalShop>>(response);
                }
                return rentalShops;
            }
        }
        public async Task<bool> DeleteRentalShop(int id)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.DeleteAsync($"api/RentalShops/DeleteRentalShop/{id}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<bool> UpdateRentalShop(RentalShop ShopChanges)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PutAsJsonAsync($"api/RentalShops/UpdateRentalShop/{ShopChanges.ID}", ShopChanges);
                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> AddBike(Bike bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PostAsJsonAsync("api/Bikes", bike);
                return res.IsSuccessStatusCode;
            }
        }
        public async Task<List<Bike>> GetBikes()
        {
            List<Bike> bikes = new List<Bike>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Bikes");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    bikes = JsonConvert.DeserializeObject<List<Bike>>(response);
                }
                return bikes;
            }
        }
        public async Task<Bike> GetBikeByID(int id)
        {
            Bike bikes = new Bike();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"api/Bikes/GetBikeByID/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    bikes = JsonConvert.DeserializeObject<Bike>(response);
                }
            }
            return bikes;
        }
        public async Task<bool> DeleteBike(int id)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.DeleteAsync($"api/Bikes/DeleteBikes/{id}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<bool> UpdateBike(Bike BikeChanges)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PutAsJsonAsync($"api/Bikes/{BikeChanges.ID}", BikeChanges);
                return res.IsSuccessStatusCode;
            }
        }

        public async Task<bool> AddReservation(Reservation reservation)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PostAsJsonAsync("api/Reservations", reservation);
                return res.IsSuccessStatusCode;
            }
        }
        public async Task<bool> DeleteReservation(int id)
        {
            bool succeeded = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.DeleteAsync($"api/Reservations/DeleteReservation/{id}");
                succeeded = res.IsSuccessStatusCode;
            }
            return succeeded;
        }
        public async Task<Reservation> GetReservationByID(int id)
        {
            Reservation reservation = new Reservation();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync($"api/Reservations/GetReservationByID/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    reservation = JsonConvert.DeserializeObject<Reservation>(response);
                }
            }
            return reservation;
        }
        public async Task<List<Reservation>> GetReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Reservations");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    reservations = JsonConvert.DeserializeObject<List<Reservation>>(response);
                }
                return reservations;
            }
        }
        public async Task<bool> UpdateReservation(Reservation ReservationChanges)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                HttpResponseMessage res = await client.PutAsJsonAsync($"api/Reservations/{ReservationChanges.ID}", ReservationChanges);
                return res.IsSuccessStatusCode;
            }
        }
    }
}
