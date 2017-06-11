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
    public class UbigeosController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: Ubigeos
        public ActionResult Index()
        {
            var ubigeo = db.ubigeo.Include(u => u.Departamento).Include(u => u.Distrito).Include(u => u.Provincia);
            return View(ubigeo.ToList());
        }

        // GET: Ubigeos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = db.ubigeo.Find(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // GET: Ubigeos/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoId = new SelectList(db.departamento, "DepartamentoId", "DepartamentoId");
            ViewBag.DistritoId = new SelectList(db.distrito, "DistritoId", "NombreDistrito");
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia");
            return View();
        }

        // POST: Ubigeos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UbigeoId,DepartamentoId,ProvinciaId,DistritoId,CodigoUbigeo")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                db.ubigeo.Add(ubigeo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoId = new SelectList(db.departamento, "DepartamentoId", "DepartamentoId", ubigeo.DepartamentoId);
            ViewBag.DistritoId = new SelectList(db.distrito, "DistritoId", "NombreDistrito", ubigeo.DistritoId);
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia", ubigeo.ProvinciaId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = db.ubigeo.Find(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoId = new SelectList(db.departamento, "DepartamentoId", "DepartamentoId", ubigeo.DepartamentoId);
            ViewBag.DistritoId = new SelectList(db.distrito, "DistritoId", "NombreDistrito", ubigeo.DistritoId);
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia", ubigeo.ProvinciaId);
            return View(ubigeo);
        }

        // POST: Ubigeos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UbigeoId,DepartamentoId,ProvinciaId,DistritoId,CodigoUbigeo")] Ubigeo ubigeo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ubigeo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoId = new SelectList(db.departamento, "DepartamentoId", "DepartamentoId", ubigeo.DepartamentoId);
            ViewBag.DistritoId = new SelectList(db.distrito, "DistritoId", "NombreDistrito", ubigeo.DistritoId);
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia", ubigeo.ProvinciaId);
            return View(ubigeo);
        }

        // GET: Ubigeos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ubigeo ubigeo = db.ubigeo.Find(id);
            if (ubigeo == null)
            {
                return HttpNotFound();
            }
            return View(ubigeo);
        }

        // POST: Ubigeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ubigeo ubigeo = db.ubigeo.Find(id);
            db.ubigeo.Remove(ubigeo);
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
