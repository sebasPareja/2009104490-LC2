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
    public class EvaluacionsController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluacion = db.evaluacion.Include(e => e.CentroAtencion).Include(e => e.EstadoEvaluacion).Include(e => e.LineaTelefonica).Include(e => e.Plan).Include(e => e.TipoEvaluacion).Include(e => e.Trabajador);
            return View(evaluacion.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion");
            ViewBag.EstadoEvaluacionId = new SelectList(db.EstadoEvaluacions, "EstadoEvaluacionId", "NombreEstadoEvaluacion");
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId");
            ViewBag.PlanId = new SelectList(db.plan, "PlanId", "Descripcion");
            ViewBag.TipoEvaluacionId = new SelectList(db.TipoEvaluacions, "TipoEvaluacionId", "NombreTipoEvaluacion");
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId");
            return View();
        }

        // POST: Evaluacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluacionId,NumeroEvaluacion,NumeroTurno,TipoEvaluacionId,EstadoEvaluacionId,CentroAtencionId,LineaTelefonicaId,PlanId,TrabajadorId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.evaluacion.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion", evaluacion.CentroAtencionId);
            ViewBag.EstadoEvaluacionId = new SelectList(db.EstadoEvaluacions, "EstadoEvaluacionId", "NombreEstadoEvaluacion", evaluacion.EstadoEvaluacionId);
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId", evaluacion.LineaTelefonicaId);
            ViewBag.PlanId = new SelectList(db.plan, "PlanId", "Descripcion", evaluacion.PlanId);
            ViewBag.TipoEvaluacionId = new SelectList(db.TipoEvaluacions, "TipoEvaluacionId", "NombreTipoEvaluacion", evaluacion.TipoEvaluacionId);
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion", evaluacion.CentroAtencionId);
            ViewBag.EstadoEvaluacionId = new SelectList(db.EstadoEvaluacions, "EstadoEvaluacionId", "NombreEstadoEvaluacion", evaluacion.EstadoEvaluacionId);
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId", evaluacion.LineaTelefonicaId);
            ViewBag.PlanId = new SelectList(db.plan, "PlanId", "Descripcion", evaluacion.PlanId);
            ViewBag.TipoEvaluacionId = new SelectList(db.TipoEvaluacions, "TipoEvaluacionId", "NombreTipoEvaluacion", evaluacion.TipoEvaluacionId);
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluacionId,NumeroEvaluacion,NumeroTurno,TipoEvaluacionId,EstadoEvaluacionId,CentroAtencionId,LineaTelefonicaId,PlanId,TrabajadorId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion", evaluacion.CentroAtencionId);
            ViewBag.EstadoEvaluacionId = new SelectList(db.EstadoEvaluacions, "EstadoEvaluacionId", "NombreEstadoEvaluacion", evaluacion.EstadoEvaluacionId);
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId", evaluacion.LineaTelefonicaId);
            ViewBag.PlanId = new SelectList(db.plan, "PlanId", "Descripcion", evaluacion.PlanId);
            ViewBag.TipoEvaluacionId = new SelectList(db.TipoEvaluacions, "TipoEvaluacionId", "NombreTipoEvaluacion", evaluacion.TipoEvaluacionId);
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId", evaluacion.TrabajadorId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.evaluacion.Find(id);
            db.evaluacion.Remove(evaluacion);
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
