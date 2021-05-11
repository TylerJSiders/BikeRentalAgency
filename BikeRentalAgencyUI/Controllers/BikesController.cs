using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgencyUI.Models.ViewModels;

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
            BikeIndexVM vm = new BikeIndexVM(await Repository.GetBikes(), await Repository.GetRentalShops());


            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Bike bike = new Bike();
            EditBikeVM vm = new EditBikeVM(new Bike(), await Repository.GetRentalShops());
            return View(vm);
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
            EditBikeVM vm = new EditBikeVM(await Repository.GetBikeByID(BikeID), await Repository.GetRentalShops());
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Bike bike)
        {
            await Repository.UpdateBike(bike);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int BikeID)
        {
            EditBikeVM vm = new EditBikeVM(await Repository.GetBikeByID(BikeID), await Repository.GetRentalShops());
            return View(vm);
        }

        public async Task<ActionResult> Delete(int BikeID)
        {
            await Repository.DeleteBike(BikeID);
            return RedirectToAction("Index");
        }
    }
}
