using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class RentalShopsController : Controller
    {
        private IBikeRentalRepo Repository;

        public RentalShopsController(IBikeRentalRepo repo)
        {
            this.Repository = repo;
        }

        public async Task<ActionResult> Index()
        {
            List<RentalShop> rentalShop = await Repository.GetRentalShops();
            return View(rentalShop);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RentalShop rentalShop = new RentalShop();

            return View(rentalShop);
        }
        [HttpPost]
        public async Task<ActionResult> Create(RentalShop rentalShop)
        {
            bool added = await Repository.AddRentalShop(rentalShop);
            if (added == false)
                return View();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            RentalShop rentalShop = await Repository.GetRentalShopByID(id);
            return View(rentalShop);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RentalShop rentalShop)
        {
            await Repository.UpdateRentalShop(rentalShop);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            RentalShop rentalShop = await Repository.GetRentalShopByID(id);
            return View(rentalShop);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await Repository.DeleteRentalShop(id);
            return RedirectToAction("Index");
        }
    }
}
