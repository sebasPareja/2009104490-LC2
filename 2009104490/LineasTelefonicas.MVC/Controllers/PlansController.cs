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
    public class PlansController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: Plans
        public ActionResult Index()
        {
            var plan = db.plan.Include(p => p.TipoPlan);
            return View(plan.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            ViewBag.TipoPlanId = new SelectList(db.TipoPlans, "TipoPlanId", "NombreTipoPlan");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,Descripcion,TipoPlanId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoPlanId = new SelectList(db.TipoPlans, "TipoPlanId", "NombreTipoPlan", plan.TipoPlanId);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoPlanId = new SelectList(db.TipoPlans, "TipoPlanId", "NombreTipoPlan", plan.TipoPlanId);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,Descripcion,TipoPlanId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoPlanId = new SelectList(db.TipoPlans, "TipoPlanId", "NombreTipoPlan", plan.TipoPlanId);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.plan.Find(id);
            db.plan.Remove(plan);
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
