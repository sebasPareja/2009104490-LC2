using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LineaTelefonica.Entities.Entities;
using LineaTelefonica.Persistance;

namespace LineasTelefonicas.WebAPI.Controllers
{
    public class VentasController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/Ventas
        public IQueryable<Venta> Getventa()
        {
            return db.venta;
        }

        // GET: api/Ventas/5
        [ResponseType(typeof(Venta))]
        public IHttpActionResult GetVenta(int id)
        {
            Venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenta(int id, Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.VentaId)
            {
                return BadRequest();
            }

            db.Entry(venta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ventas
        [ResponseType(typeof(Venta))]
        public IHttpActionResult PostVenta(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.venta.Add(venta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = venta.VentaId }, venta);
        }

        // DELETE: api/Ventas/5
        [ResponseType(typeof(Venta))]
        public IHttpActionResult DeleteVenta(int id)
        {
            Venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return NotFound();
            }

            db.venta.Remove(venta);
            db.SaveChanges();

            return Ok(venta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentaExists(int id)
        {
            return db.venta.Count(e => e.VentaId == id) > 0;
        }
    }
}