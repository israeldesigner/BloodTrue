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
    public class CidadeController : ApiController
    {
        private Contexto db = new Contexto();

        // GET api/Cidade
        public IQueryable<Cidade> GetCidade()
        {
            return db.Cidade;
        }

        // GET api/Cidade/5
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult GetCidade(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return NotFound();
            }

            return Ok(cidade);
        }

        // PUT api/Cidade/5
        public IHttpActionResult PutCidade(int id, Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cidade.CidadeId)
            {
                return BadRequest();
            }

            db.Entry(cidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
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

        // POST api/Cidade
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult PostCidade(Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cidade.Add(cidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cidade.CidadeId }, cidade);
        }

        // DELETE api/Cidade/5
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult DeleteCidade(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return NotFound();
            }

            db.Cidade.Remove(cidade);
            db.SaveChanges();

            return Ok(cidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CidadeExists(int id)
        {
            return db.Cidade.Count(e => e.CidadeId == id) > 0;
        }
    }
}