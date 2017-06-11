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
    public class TipoEvaluacionsController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: TipoEvaluacions
        public ActionResult Index()
        {
            return View(db.TipoEvaluacions.ToList());
        }

        // GET: TipoEvaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEvaluacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoEvaluacionId,NombreTipoEvaluacion")] TipoEvaluacion tipoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoEvaluacions.Add(tipoEvaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // POST: TipoEvaluacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoEvaluacionId,NombreTipoEvaluacion")] TipoEvaluacion tipoEvaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEvaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEvaluacion);
        }

        // GET: TipoEvaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            if (tipoEvaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoEvaluacion);
        }

        // POST: TipoEvaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEvaluacion tipoEvaluacion = db.TipoEvaluacions.Find(id);
            db.TipoEvaluacions.Remove(tipoEvaluacion);
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
