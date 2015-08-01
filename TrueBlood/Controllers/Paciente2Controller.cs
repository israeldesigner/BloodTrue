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
    public class Paciente2Controller : ApiController
    {
        private Contexto db = new Contexto();

        // GET api/Paciente2
        public IQueryable<Paciente> GetPaciente()
        {
            return db.Paciente;
        }

        // GET api/Paciente2/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT api/Paciente2/5
        public IHttpActionResult PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.PacienteId)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST api/Paciente2
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paciente.Add(paciente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paciente.PacienteId }, paciente);
        }

        // DELETE api/Paciente2/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult DeletePaciente(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Paciente.Remove(paciente);
            db.SaveChanges();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Paciente.Count(e => e.PacienteId == id) > 0;
        }
    }
}