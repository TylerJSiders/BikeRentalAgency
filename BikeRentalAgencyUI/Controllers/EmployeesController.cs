using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;

namespace BikeRentalAgencyUI.Controllers
{
    public class EmployeesController : Controller
    {
        private IBikeRentalRepo Repository;

        public EmployeesController(IBikeRentalRepo repo)
        {
            this.Repository = repo;
        }

        public async Task<ActionResult> Index()
        {
            List<Employee> employees = await Repository.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Employee employee = new Employee();

            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            //TODO Tyler: Add logic to check if rental shop exists
            bool added = await Repository.AddEmployee(employee);
            if (added == false)
                return View();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int EmployeeID)
        {
            Employee employee = await Repository.GetEmployeeByID(EmployeeID);
            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            bool Succeeded = await Repository.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int EmployeeID)
        {
            Employee employee = await Repository.GetEmployeeByID(EmployeeID);
            return View(employee);
        }

        public async Task<ActionResult> Delete(int EmployeeID)
        {
            bool success = await Repository.DeleteEmployee(EmployeeID);
            return RedirectToAction("Index");
        }
    }
}
