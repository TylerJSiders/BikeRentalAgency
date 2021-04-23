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

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalShopsController : ControllerBase
    {
        private IDBRepository Repository;

        public RentalShopsController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/RentalShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalShop>>> GetShops()
        {
            var rentalShops = await Repository.GetRentalShops();
            if (rentalShops.Count <= 0)
                return NoContent();

            return rentalShops;
        }

        // GET: api/RentalShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalShop>> GetRentalShop(int id)
        {
            if (!Repository.RentalShopExists(id))
                return NoContent();
            return await Repository.GetRentalShopByID(id);
        }

        // PUT: api/RentalShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateRentalShop/{id}")]
        public async Task<ActionResult<RentalShop>> PutRentalShop(int id, RentalShop rentalShop)
        {
            if (id != rentalShop.ID)
                return BadRequest();
            if (!Repository.RentalShopExists(id))
                return NoContent();

            return await Repository.UpdateRentalShop(rentalShop);
        }

        // POST: api/RentalShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentalShop>> PostRentalShop(RentalShop rentalShop)
        {
            return await Repository.AddRentalShop(rentalShop);
        }

        // DELETE: api/RentalShops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentalShop>> DeleteRentalShop(int id)
        {
            if (!Repository.RentalShopExists(id))
                return NoContent();
            return await Repository.DeleteRentalShop(id);
        }

    }
}
