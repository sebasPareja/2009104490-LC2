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
    public class DistritoesController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: Distritoes
        public ActionResult Index()
        {
            var distrito = db.distrito.Include(d => d.Provincia);
            return View(distrito.ToList());
        }

        // GET: Distritoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritoes/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia");
            return View();
        }

        // POST: Distritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,NombreDistrito,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.distrito.Add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // POST: Distritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,NombreDistrito,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(db.provincia, "ProvinciaId", "NombreProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = db.distrito.Find(id);
            db.distrito.Remove(distrito);
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
