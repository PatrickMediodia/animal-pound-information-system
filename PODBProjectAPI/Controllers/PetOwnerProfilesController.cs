using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PODBProjectAPI;

namespace PODBProjectAPI.Controllers
{
    [Authorize]
    public class PetOwnerProfilesController : ApiController
    {
        private PODBProjectEntities db = new PODBProjectEntities();

        // GET: api/PetOwnerProfiles
        public IQueryable<PetOwnerProfile> GetPetOwnerProfiles()
        {
            return db.PetOwnerProfiles;
        }

        // GET: api/PetOwnerProfiles/5
        [ResponseType(typeof(PetOwnerProfile))]
        public IHttpActionResult GetPetOwnerProfile(int id)
        {
            PetOwnerProfile petOwnerProfile = db.PetOwnerProfiles.Find(id);
            if (petOwnerProfile == null)
            {
                return NotFound();
            }

            return Ok(petOwnerProfile);
        }

        // PUT: api/PetOwnerProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPetOwnerProfile(int id, PetOwnerProfile petOwnerProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petOwnerProfile.profileId)
            {
                return BadRequest();
            }

            db.Entry(petOwnerProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PetOwnerProfiles
        [ResponseType(typeof(PetOwnerProfile))]
        public IHttpActionResult PostPetOwnerProfile(PetOwnerProfile petOwnerProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetOwnerProfiles.Add(petOwnerProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petOwnerProfile.profileId }, petOwnerProfile);
        }

        // DELETE: api/PetOwnerProfiles/5
        [ResponseType(typeof(PetOwnerProfile))]
        public IHttpActionResult DeletePetOwnerProfile(int id)
        {
            PetOwnerProfile petOwnerProfile = db.PetOwnerProfiles.Find(id);
            if (petOwnerProfile == null)
            {
                return NotFound();
            }

            db.PetOwnerProfiles.Remove(petOwnerProfile);
            db.SaveChanges();

            return Ok(petOwnerProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetOwnerProfileExists(int id)
        {
            return db.PetOwnerProfiles.Count(e => e.profileId == id) > 0;
        }
    }
}