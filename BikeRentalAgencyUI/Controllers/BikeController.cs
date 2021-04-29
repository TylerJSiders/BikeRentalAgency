using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP;
using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;

namespace BikeRentalAgencyUI.Controllers
{
	public class BikeController : Controller
    {
        private IBikeRentalRepo Repository;

        public BikeController(IBikeRentalRepo repo)
        {
            this.Repository = repo;
        }

        public async Task<ActionResult> Index()
        {
            list<Bike> bikes = await Repository.GetBikes();
            return View(bikes);
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
            bool added = await Repositorty.AddBike(bike);
            if (added == false)
                return View();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int BikeID)
        {
            Bike bike = await Repository.GetBikeById(BikeID);
            return View(bike);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Bike bike)
        {
            bool Succeeded = await Repository.UpdateBike(bike);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int BikeID)
        {
            Bike bike = await Repository.GetBikeById(BikeID);
            return View(bike);
        }

        public async Task<ActionResult> Delete(int BikeID)
        {
            bool success = await Repository.DeleteEmployee(BikeID);
            return RedirectToAction("Index")
        }
    }
}


