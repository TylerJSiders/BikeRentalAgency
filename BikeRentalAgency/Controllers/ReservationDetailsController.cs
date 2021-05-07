//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using BikeRentalAgency.Models;
//using BikeRentalAgency.Models.Interfaces;
//using BikeRentalAgency.Models.Repositories;
//using BikeRentalLibrary;

//namespace BikeRentalAgency.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReservationDetailsController : ControllerBase
//    {
//        private IDBRepository Repository;

//        public ReservationDetailsController(IDBRepository context)
//        {
//            Repository = context;
//        }

//        // GET: api/ReservationDetails
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ReservationDetails>>> GetReservationDetails()
//        {
//            var reservationDetails = await Repository.GetReservationDetails();
//            if (reservationDetails.Count <= 0)
//                return NoContent();

//            return reservationDetails;
//        }

//        // GET: api/ReservationDetails/1
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ReservationDetails>> GetReservationDetails(int id)
//        {
//            if (!Repository.ReservationExists(id))
//                return NoContent();
//            return await Repository.GetReservationDetailsById(id);
//        }

//        // PUT: api/ReservationDetails/1
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("UpdateReservationDetails/{id}")]
//        public async Task<ActionResult<ReservationDetails>> PutReservationDetails(int id, ReservationDetails reservationDetails)
//        {
//            if (id != reservationDetails.ReservationID)
//                return BadRequest();
//            if (!Repository.ReservationExists(id))
//                return NoContent();

//            return await Repository.UpdateReservationDetails(reservationDetails);
//        }

//        // POST: api/ReservationDetails
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<ReservationDetails>> PostReservationDetails(ReservationDetails reservationDetails)
//        {
//            if (!Repository.ReservationExists(reservationDetails.ReservationID))
//                return NoContent();

//            return await Repository.AddReservationDetails(reservationDetails);
//        }

//        // DELETE: api/ReservationDetails/1
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ReservationDetails>> DeleteReservationDetails(int id)
//        {
//            if (!Repository.ReservationExists(id))
//                return NoContent();
//            return await Repository.DeleteReservationDetails(id);
//        }

//    }
//}