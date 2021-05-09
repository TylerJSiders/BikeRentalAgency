using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRentalAgency.Models;
using BikeRentalAgency.Models.Interfaces;
using BikeRentalAgency.Models.Repositories;
using BikeRentalLibrary;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IDBRepository Repository;

        public ReservationsController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await Repository.GetReservations();
            //if (reservations.Count <= 0)
            //    return NoContent();

            return reservations;
        }

        // GET: api/Reservations/1
        [HttpGet("GetReservationByID/{id}")]
        public async Task<ActionResult<Reservation>> GetReservationByID(int id)
        {
            if (!Repository.ReservationExists(id))
                return NoContent();
            return await Repository.GetReservationByID(id);
        }

        // PUT: api/Reservations/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateReservation/{id}")]
        public async Task<ActionResult<Reservation>> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.ID)
                return BadRequest();
            if (!Repository.ReservationExists(id))
                return NoContent();

            return await Repository.UpdateReservation(reservation);
        }

        // POST: api/Reservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            if (!Repository.RentalShopExists(reservation.LocationStart))
                return NoContent();
            if (!Repository.RentalShopExists(reservation.LocationEnd))
                return NoContent();
            //if (!Repository.CustomerExists(reservation.CustomerID))
            //    return NoContent();

            return await Repository.AddReservation(reservation);
        }

        // DELETE: api/Reservation/1
        [HttpDelete("DeleteReservation/{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int id)
        {
            if (!Repository.ReservationExists(id))
                return NoContent();
            return await Repository.DeleteReservation(id);
        }

    }
}