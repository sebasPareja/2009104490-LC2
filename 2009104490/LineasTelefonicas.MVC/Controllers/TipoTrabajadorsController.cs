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
    public class TipoTrabajadorsController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: TipoTrabajadors
        public ActionResult Index()
        {
            return View(db.TipoTrabajadors.ToList());
        }

        // GET: TipoTrabajadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            if (tipoTrabajador == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajador);
        }

        // GET: TipoTrabajadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTrabajadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoTrabajadorId,NombreTipoTrabajador")] TipoTrabajador tipoTrabajador)
        {
            if (ModelState.IsValid)
            {
                db.TipoTrabajadors.Add(tipoTrabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTrabajador);
        }

        // GET: TipoTrabajadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            if (tipoTrabajador == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajador);
        }

        // POST: TipoTrabajadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoTrabajadorId,NombreTipoTrabajador")] TipoTrabajador tipoTrabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTrabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTrabajador);
        }

        // GET: TipoTrabajadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            if (tipoTrabajador == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajador);
        }

        // POST: TipoTrabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            db.TipoTrabajadors.Remove(tipoTrabajador);
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
