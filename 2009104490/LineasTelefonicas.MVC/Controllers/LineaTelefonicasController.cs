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
    public class LineaTelefonicasController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: LineaTelefonicas
        public ActionResult Index()
        {
            var lineatelefonica = db.lineatelefonica.Include(l => l.AdministradorLinea).Include(l => l.TipoLinea);
            return View(lineatelefonica.ToList());
        }

        // GET: LineaTelefonicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica = db.lineatelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Create
        public ActionResult Create()
        {
            ViewBag.AdministradorLineaId = new SelectList(db.administradorLinea, "AdministradorLineaId", "NombreAdministradorLinea");
            ViewBag.TipoLineaId = new SelectList(db.TipoLineas, "TipoLineaId", "NombreTipoLinea");
            return View();
        }

        // POST: LineaTelefonicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineaTelefonicaId,NumeroLineaTelefonica,AdministradorLineaId,TipoLineaId")] LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                db.lineatelefonica.Add(lineaTelefonica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdministradorLineaId = new SelectList(db.administradorLinea, "AdministradorLineaId", "NombreAdministradorLinea", lineaTelefonica.AdministradorLineaId);
            ViewBag.TipoLineaId = new SelectList(db.TipoLineas, "TipoLineaId", "NombreTipoLinea", lineaTelefonica.TipoLineaId);
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica = db.lineatelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministradorLineaId = new SelectList(db.administradorLinea, "AdministradorLineaId", "NombreAdministradorLinea", lineaTelefonica.AdministradorLineaId);
            ViewBag.TipoLineaId = new SelectList(db.TipoLineas, "TipoLineaId", "NombreTipoLinea", lineaTelefonica.TipoLineaId);
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineaTelefonicaId,NumeroLineaTelefonica,AdministradorLineaId,TipoLineaId")] LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineaTelefonica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdministradorLineaId = new SelectList(db.administradorLinea, "AdministradorLineaId", "NombreAdministradorLinea", lineaTelefonica.AdministradorLineaId);
            ViewBag.TipoLineaId = new SelectList(db.TipoLineas, "TipoLineaId", "NombreTipoLinea", lineaTelefonica.TipoLineaId);
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica = db.lineatelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica = db.lineatelefonica.Find(id);
            db.lineatelefonica.Remove(lineaTelefonica);
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
