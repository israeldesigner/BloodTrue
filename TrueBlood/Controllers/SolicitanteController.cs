using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrueBlood.Models;

namespace TrueBlood.Controllers
{
    public class SolicitanteController : Controller
    {
        private Contexto db = new Contexto();

        // GET: /Solicitante/
        public ActionResult Index()
        {
            var paciente = db.Paciente.Include(p => p.Cidade).Include(p => p.Hospital);
            return View(paciente.ToList());
        }

        // GET: /Solicitante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: /Solicitante/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome");
            ViewBag.HospitalId = new SelectList(db.Hospital, "HospitalId", "Nome");
            return View();
        }

        // POST: /Solicitante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PacienteId,Nome,NumeroDoadores,Email,Prazo,HospitalId,CidadeId")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome", paciente.CidadeId);
            ViewBag.HospitalId = new SelectList(db.Hospital, "HospitalId", "Nome", paciente.HospitalId);
            return View(paciente);
        }

        // GET: /Solicitante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome", paciente.CidadeId);
            ViewBag.HospitalId = new SelectList(db.Hospital, "HospitalId", "Nome", paciente.HospitalId);
            return View(paciente);
        }

        // POST: /Solicitante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PacienteId,Nome,NumeroDoadores,Email,Prazo,HospitalId,CidadeId")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidade, "CidadeId", "Nome", paciente.CidadeId);
            ViewBag.HospitalId = new SelectList(db.Hospital, "HospitalId", "Nome", paciente.HospitalId);
            return View(paciente);
        }

        // GET: /Solicitante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: /Solicitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
