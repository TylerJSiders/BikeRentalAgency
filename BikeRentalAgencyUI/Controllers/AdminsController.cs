using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class AdminsController : Controller
    {
        private IBikeRentalRepo Repository;

        public AdminsController(IBikeRentalRepo repo)
        {
            this.Repository = repo;
        }

        public async Task<ActionResult> Index()
        {
            List<AdminLogin> admins = await Repository.GetAdmins();
            return View(admins);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AdminLogin admin = new AdminLogin();
            return View(admin);
        }
        [HttpPost]
        public async Task<ActionResult> Create(AdminLogin adminLogin)
        {
            bool added = await Repository.AddAdmin(adminLogin);
            if (added == false)
                return View();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            AdminLogin adminLogin = await Repository.GetAdminByID(id);
            return View(adminLogin);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(AdminLogin adminLogin)
        {
            await Repository.UpdateAdmin(adminLogin);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            AdminLogin adminLogin = await Repository.GetAdminByID(id);
            return View(adminLogin);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await Repository.DeleteAdmin(id);
            return RedirectToAction("Index");
        }
    }
}
