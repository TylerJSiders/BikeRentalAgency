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
    public class BikesController : ControllerBase
    {
        private IDBRepository Repository;

        public BikesController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/Bikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bike>>> GetBikes()
        {
            var bikes = await Repository.GetBikes();
            if (bikes.Count <= 0)
                return NoContent();

            return bikes;
        }

        // GET: api/Bikes/5
        [HttpGet("GetBikeByID/{id}")]
        public async Task<ActionResult<Bike>> GetBikeByID(int id)
        {
            if (!Repository.BikeExists(id))
                return NoContent();
            return await Repository.GetBikeByID(id);
        }

        // PUT: api/Bike/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateBike/{id}")]
        public async Task<ActionResult<Bike>> PutBike(int id, Bike bike)
        {
            if (id != bike.ID)
                return BadRequest();
            if (!Repository.BikeExists(id))
                return NoContent();

            return await Repository.UpdateBike(bike);
        }

        // POST: api/Bikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bike>> PostBike(Bike bike)
        {
            if(!Repository.RentalShopExists(bike.CurrentLocationID))
            {
                return NoContent();
            }
            return await Repository.AddBike(bike);
        }

        // DELETE: api/Bikes/5
        [HttpDelete("DeleteBike/{id}")]
        public async Task<ActionResult<Bike>> DeleteBike(int id)
        {
            if (!Repository.BikeExists(id))
                return NoContent();
            return await Repository.DeleteBike(id);
        }

    }
}
