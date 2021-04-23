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
    public class SpecialFeaturesController : ControllerBase
    {
        private IDBRepository Repository;

        public SpecialFeaturesController(IDBRepository context)
        {
            Repository = context;
        }

        // GET: api/SpecialFeatures
        //[HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialFeature>>> GetSpecialFeatures()
        {
            var ListOfSpecialFeatures = await Repository.GetSpecialFeatures();
            if (ListOfSpecialFeatures.Count <= 0)
                return NoContent();
            return ListOfSpecialFeatures;
        }

        // GET: api/SpecialFeatures/5
        [HttpGet("GetSpecialFeatureByID{id}")]
        public async Task<ActionResult<SpecialFeature>> GetSpecialFeature(int id)
        {
            if (!Repository.SpecialFeatureExists(id))
                return NoContent();

            return await Repository.GetSpecialFeatureByID(id);

        }

        //// PUT: api/SpecialFeatures/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSpecialFeature/{id}")]
        public async Task<ActionResult<SpecialFeature>> PutSpecialFeature(int id, SpecialFeature specialFeature)
        {
            if (id != specialFeature.ID)
            {
                return BadRequest();
            }
            if (!Repository.SpecialFeatureExists(id))
                return NoContent();

            return await Repository.UpdateSpecialFeature(specialFeature);
        }

        //// POST: api/SpecialFeatures
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecialFeature>> PostSpecialFeature(SpecialFeature specialFeature)
        {
            return await Repository.CreateSpecialFeature(specialFeature);

        }

        //// DELETE: api/SpecialFeatures/5
        [HttpDelete("DeleteSpecialFeature/{id}")]
        public async Task<ActionResult<SpecialFeature>> DeleteSpecialFeature(int id)
        {
            if (!Repository.SpecialFeatureExists(id))
                return NoContent();


            var FeatureRemoved = await Repository.DeleteSpecialFeature(id);
            return FeatureRemoved;
            
        }

    }
}
