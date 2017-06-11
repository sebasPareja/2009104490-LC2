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
    public class TrabajadorsController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: Trabajadors
        public ActionResult Index()
        {
            var trabajador = db.trabajador.Include(t => t.TipoTrabajador);
            return View(trabajador.ToList());
        }

        // GET: Trabajadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public ActionResult Create()
        {
            ViewBag.TipoTrabajadorId = new SelectList(db.TipoTrabajadors, "TipoTrabajadorId", "TipoTrabajadorId");
            return View();
        }

        // POST: Trabajadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajadorId,NombreTrabajador,TipoTrabajadorId")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.trabajador.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoTrabajadorId = new SelectList(db.TipoTrabajadors, "TipoTrabajadorId", "TipoTrabajadorId", trabajador.TipoTrabajadorId);
            return View(trabajador);
        }

        // GET: Trabajadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoTrabajadorId = new SelectList(db.TipoTrabajadors, "TipoTrabajadorId", "TipoTrabajadorId", trabajador.TipoTrabajadorId);
            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajadorId,NombreTrabajador,TipoTrabajadorId")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoTrabajadorId = new SelectList(db.TipoTrabajadors, "TipoTrabajadorId", "TipoTrabajadorId", trabajador.TipoTrabajadorId);
            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajador trabajador = db.trabajador.Find(id);
            db.trabajador.Remove(trabajador);
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
