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
    public class TipoPlansController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: TipoPlans
        public ActionResult Index()
        {
            return View(db.TipoPlans.ToList());
        }

        // GET: TipoPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoPlan = db.TipoPlans.Find(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // GET: TipoPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPlanId,NombreTipoPlan")] TipoPlan tipoPlan)
        {
            if (ModelState.IsValid)
            {
                db.TipoPlans.Add(tipoPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPlan);
        }

        // GET: TipoPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoPlan = db.TipoPlans.Find(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // POST: TipoPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPlanId,NombreTipoPlan")] TipoPlan tipoPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPlan);
        }

        // GET: TipoPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoPlan = db.TipoPlans.Find(id);
            if (tipoPlan == null)
            {
                return HttpNotFound();
            }
            return View(tipoPlan);
        }

        // POST: TipoPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPlan tipoPlan = db.TipoPlans.Find(id);
            db.TipoPlans.Remove(tipoPlan);
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
