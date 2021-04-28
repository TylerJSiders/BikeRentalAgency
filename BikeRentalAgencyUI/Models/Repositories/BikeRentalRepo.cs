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

    }
}
