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
using TrueBlood.Models;

namespace TrueBlood.Controllers
{
    public class HospitalController : ApiController
    {
        private Contexto db = new Contexto();

        // GET api/Hospital
        public IQueryable<Hospital> GetHospital()
        {
            return db.Hospital;
        }

        // GET api/Hospital/5
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult GetHospital(int id)
        {
            Hospital hospital = db.Hospital.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        // PUT api/Hospital/5
        public IHttpActionResult PutHospital(int id, Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospital.HospitalId)
            {
                return BadRequest();
            }

            db.Entry(hospital).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
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

        // POST api/Hospital
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult PostHospital(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hospital.Add(hospital);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospital.HospitalId }, hospital);
        }

        // DELETE api/Hospital/5
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult DeleteHospital(int id)
        {
            Hospital hospital = db.Hospital.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }

            db.Hospital.Remove(hospital);
            db.SaveChanges();

            return Ok(hospital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalExists(int id)
        {
            return db.Hospital.Count(e => e.HospitalId == id) > 0;
        }
    }
}