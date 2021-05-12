using BikeRentalAgency.Models.Interfaces;
using BikeRentalLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : Controller
    {
        private IDBRepository Repository;

        public AdminsController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminLogin>>> GetAdmins()
        {
            var admins = await Repository.GetAdmins();
            //if (rentalShops.Count <= 0)
            //    return NoContent();

            return admins;
        }

        // GET: api/Admins/5
        [HttpGet("GetAdminByID/{id}")]
        public async Task<ActionResult<AdminLogin>> GetAdminByID(int id)
        {
            if (!Repository.AdminExists(id))
                return NoContent();
            return await Repository.GetAdminByID(id);
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateAdmin/{id}")]
        public async Task<ActionResult<AdminLogin>> PutAdmin(int id, AdminLogin admins)
        {
            if (id != admins.ID)
                return BadRequest();
            if (!Repository.AdminExists(id))
                return NoContent();

            return await Repository.UpdateAdmin(admins);
        }

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminLogin>> PostAdmin(AdminLogin adminLogin)
        {
            return await Repository.AddAdmin(adminLogin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("DeleteAdmin/{id}")]
        public async Task<ActionResult<AdminLogin>> DeleteAdmins(int id)
        {
            if (!Repository.AdminExists(id))
                return NoContent();
            return await Repository.DeleteAdmin(id);
        }
    }
}
