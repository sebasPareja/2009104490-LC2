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
    public class EquipoCelularsController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: EquipoCelulars
        public ActionResult Index()
        {
            var equipocelular = db.equipocelular.Include(e => e.AdministradorEquipo);
            return View(equipocelular.ToList());
        }

        // GET: EquipoCelulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = db.equipocelular.Find(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Create
        public ActionResult Create()
        {
            ViewBag.AdministradorEquipoId = new SelectList(db.administradorEquipo, "AdministradorEquipoId", "NombreAdministradorEquipo");
            return View();
        }

        // POST: EquipoCelulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoCelularId,NumeroEquipoCelular,AdministradorEquipoId")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                db.equipocelular.Add(equipoCelular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdministradorEquipoId = new SelectList(db.administradorEquipo, "AdministradorEquipoId", "NombreAdministradorEquipo", equipoCelular.AdministradorEquipoId);
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = db.equipocelular.Find(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministradorEquipoId = new SelectList(db.administradorEquipo, "AdministradorEquipoId", "NombreAdministradorEquipo", equipoCelular.AdministradorEquipoId);
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoCelularId,NumeroEquipoCelular,AdministradorEquipoId")] EquipoCelular equipoCelular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoCelular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdministradorEquipoId = new SelectList(db.administradorEquipo, "AdministradorEquipoId", "NombreAdministradorEquipo", equipoCelular.AdministradorEquipoId);
            return View(equipoCelular);
        }

        // GET: EquipoCelulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipoCelular = db.equipocelular.Find(id);
            if (equipoCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoCelular);
        }

        // POST: EquipoCelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoCelular equipoCelular = db.equipocelular.Find(id);
            db.equipocelular.Remove(equipoCelular);
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
