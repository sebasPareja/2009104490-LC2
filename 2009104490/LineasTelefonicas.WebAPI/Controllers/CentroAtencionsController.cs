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
    public class CentroAtencionsController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/CentroAtencions
        public IQueryable<CentroAtencion> Getcentroatencion()
        {
            return db.centroatencion;
        }

        // GET: api/CentroAtencions/5
        [ResponseType(typeof(CentroAtencion))]
        public IHttpActionResult GetCentroAtencion(int id)
        {
            CentroAtencion centroAtencion = db.centroatencion.Find(id);
            if (centroAtencion == null)
            {
                return NotFound();
            }

            return Ok(centroAtencion);
        }

        // PUT: api/CentroAtencions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCentroAtencion(int id, CentroAtencion centroAtencion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != centroAtencion.CentroAtencionId)
            {
                return BadRequest();
            }

            db.Entry(centroAtencion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroAtencionExists(id))
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

        // POST: api/CentroAtencions
        [ResponseType(typeof(CentroAtencion))]
        public IHttpActionResult PostCentroAtencion(CentroAtencion centroAtencion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.centroatencion.Add(centroAtencion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = centroAtencion.CentroAtencionId }, centroAtencion);
        }

        // DELETE: api/CentroAtencions/5
        [ResponseType(typeof(CentroAtencion))]
        public IHttpActionResult DeleteCentroAtencion(int id)
        {
            CentroAtencion centroAtencion = db.centroatencion.Find(id);
            if (centroAtencion == null)
            {
                return NotFound();
            }

            db.centroatencion.Remove(centroAtencion);
            db.SaveChanges();

            return Ok(centroAtencion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CentroAtencionExists(int id)
        {
            return db.centroatencion.Count(e => e.CentroAtencionId == id) > 0;
        }
    }
}