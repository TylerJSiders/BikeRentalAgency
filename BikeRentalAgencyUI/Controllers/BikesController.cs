using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class BikesController : Controller
    {
        private IBikeRentalRepo Repository;

        public BikesController(IBikeRentalRepo repo)
        {
            this.Repository = repo;
        }

        public async Task<ActionResult> Index()
        {
            List<Bike> employees = await Repository.GetBikes();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Bike bike = new Bike();

            return View(bike);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Bike bike)
        {
            bool added = await Repository.AddBike(bike);
            if (added == false)
                return View();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int BikeID)
        {
            Bike bike = await Repository.GetBikeByID(BikeID);
            return View(bike);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Bike bike)
        {
            await Repository.UpdateBike(bike);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int BikeID)
        {
            Bike bike = await Repository.GetBikeByID(BikeID);
            return View(bike);
        }

        public async Task<ActionResult> Delete(int BikeID)
        {
            await Repository.DeleteBike(BikeID);
            return RedirectToAction("Index");
        }
    }
}
