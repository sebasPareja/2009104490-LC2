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
    public class VentasController : Controller
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: Ventas
        public ActionResult Index()
        {
            var venta = db.venta.Include(v => v.CentroAtencion).Include(v => v.Evaluacion).Include(v => v.LineaTelefonica).Include(v => v.TipoPago).Include(v => v.Trabajador);
            return View(venta.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion");
            ViewBag.EvaluacionId = new SelectList(db.evaluacion, "EvaluacionId", "EvaluacionId");
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId");
            ViewBag.TipoPagoId = new SelectList(db.TipoPagoes, "TipoPagoId", "NombreTipoPago");
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,Fecha,Monto,CentroAtencionId,EvaluacionId,LineaTelefonicaId,TipoPagoId,TrabajadorId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion", venta.CentroAtencionId);
            ViewBag.EvaluacionId = new SelectList(db.evaluacion, "EvaluacionId", "EvaluacionId", venta.EvaluacionId);
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId", venta.LineaTelefonicaId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagoes, "TipoPagoId", "NombreTipoPago", venta.TipoPagoId);
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId", venta.TrabajadorId);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion", venta.CentroAtencionId);
            ViewBag.EvaluacionId = new SelectList(db.evaluacion, "EvaluacionId", "EvaluacionId", venta.EvaluacionId);
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId", venta.LineaTelefonicaId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagoes, "TipoPagoId", "NombreTipoPago", venta.TipoPagoId);
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId", venta.TrabajadorId);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,Fecha,Monto,CentroAtencionId,EvaluacionId,LineaTelefonicaId,TipoPagoId,TrabajadorId")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroAtencionId = new SelectList(db.centroatencion, "CentroAtencionId", "NombreCentroAtencion", venta.CentroAtencionId);
            ViewBag.EvaluacionId = new SelectList(db.evaluacion, "EvaluacionId", "EvaluacionId", venta.EvaluacionId);
            ViewBag.LineaTelefonicaId = new SelectList(db.lineatelefonica, "LineaTelefonicaId", "LineaTelefonicaId", venta.LineaTelefonicaId);
            ViewBag.TipoPagoId = new SelectList(db.TipoPagoes, "TipoPagoId", "NombreTipoPago", venta.TipoPagoId);
            ViewBag.TrabajadorId = new SelectList(db.trabajador, "TrabajadorId", "TrabajadorId", venta.TrabajadorId);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.venta.Find(id);
            db.venta.Remove(venta);
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
