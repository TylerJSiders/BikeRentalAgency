using BikeRentalAgencyUI.Models.Interfaces;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Controllers
{
    public class ReservationsController : Controller
    {
        private IBikeRentalRepo Repository;

        public ReservationsController(IBikeRentalRepo repo)
        {
            this.Repository = repo;
        }

        public async Task<ActionResult> Index()
        {
            List<Reservation> reservations = await Repository.GetReservations();
            return View(reservations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Reservation reservation = new Reservation();

            return View(reservation);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Reservation reservation)
        {
            bool added = await Repository.AddReservation(reservation);
            if (added == false)
                return View();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int ReservationID)
        {
            Reservation reservation = await Repository.GetReservationByID(ReservationID);
            return View(reservation);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Reservation reservation)
        {
            await Repository.UpdateReservation(reservation);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int ReservationID)
        {
            Reservation reservation = await Repository.GetReservationByID(ReservationID);
            return View(reservation);
        }

        public async Task<ActionResult> Delete(int ReservationID)
        {
            await Repository.DeleteReservation(ReservationID);
            return RedirectToAction("Index");
        }
    }
}
