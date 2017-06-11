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
    public class TipoLineasController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: TipoLineas
        public ActionResult Index()
        {
            return View(db.TipoLineas.ToList());
        }

        // GET: TipoLineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinea tipoLinea = db.TipoLineas.Find(id);
            if (tipoLinea == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinea);
        }

        // GET: TipoLineas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLineas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoLineaId,NombreTipoLinea")] TipoLinea tipoLinea)
        {
            if (ModelState.IsValid)
            {
                db.TipoLineas.Add(tipoLinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLinea);
        }

        // GET: TipoLineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinea tipoLinea = db.TipoLineas.Find(id);
            if (tipoLinea == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinea);
        }

        // POST: TipoLineas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoLineaId,NombreTipoLinea")] TipoLinea tipoLinea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLinea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLinea);
        }

        // GET: TipoLineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinea tipoLinea = db.TipoLineas.Find(id);
            if (tipoLinea == null)
            {
                return HttpNotFound();
            }
            return View(tipoLinea);
        }

        // POST: TipoLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLinea tipoLinea = db.TipoLineas.Find(id);
            db.TipoLineas.Remove(tipoLinea);
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
