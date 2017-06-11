using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LineaTelefonica.Entities.Entities;
using LineaTelefonica.Persistance;

namespace LineasTelefonicas.MVC.Controllers
{
    public class EstadoEvaluacionsController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: EstadoEvaluacions
        public ActionResult Index()
        {
            return View(db.EstadoEvaluacions.ToList());
        }

        // GET: EstadoEvaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoEvaluacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoEvaluacionId,NombreEstadoEvaluacion")] EstadoEvaluacion estadoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                db.EstadoEvaluacions.Add(estadoEvaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // POST: EstadoEvaluacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoEvaluacionId,NombreEstadoEvaluacion")] EstadoEvaluacion estadoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoEvaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoEvaluacion);
        }

        // GET: EstadoEvaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            if (estadoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoEvaluacion);
        }

        // POST: EstadoEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            db.EstadoEvaluacions.Remove(estadoEvaluacion);
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
