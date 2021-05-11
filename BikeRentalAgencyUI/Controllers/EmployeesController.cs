using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using BikeRentalAgencyUI.Models.ViewModels;

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
            EmployeeIndexVM vm = new EmployeeIndexVM(await Repository.GetEmployees(), await Repository.GetRentalShops());
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Employee employee = new Employee();
            EditEmployeeVM vm = new EditEmployeeVM(new Employee(), await Repository.GetRentalShops());
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            bool added = await Repository.AddEmployee(employee);
            if (added == false)
                return View();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int EmployeeID)
        {
            Employee employee = await Repository.GetEmployeeByID(EmployeeID);
            EditEmployeeVM vm = new EditEmployeeVM(await Repository.GetEmployeeByID(EmployeeID), await Repository.GetRentalShops());
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            await Repository.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int EmployeeID)
        {
            Employee employee = await Repository.GetEmployeeByID(EmployeeID);
            EditEmployeeVM vm = new EditEmployeeVM(await Repository.GetEmployeeByID(EmployeeID), await Repository.GetRentalShops());
            return View(vm);
        }

        public async Task<ActionResult> Delete(int EmployeeID)
        {
            await Repository.DeleteEmployee(EmployeeID);
            return RedirectToAction("Index");
        }
    }
}
