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
    public class TipoLineasController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/TipoLineas
        public IQueryable<TipoLinea> GetTipoLineas()
        {
            return db.TipoLineas;
        }

        // GET: api/TipoLineas/5
        [ResponseType(typeof(TipoLinea))]
        public IHttpActionResult GetTipoLinea(int id)
        {
            TipoLinea tipoLinea = db.TipoLineas.Find(id);
            if (tipoLinea == null)
            {
                return NotFound();
            }

            return Ok(tipoLinea);
        }

        // PUT: api/TipoLineas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoLinea(int id, TipoLinea tipoLinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoLinea.TipoLineaId)
            {
                return BadRequest();
            }

            db.Entry(tipoLinea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLineaExists(id))
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

        // POST: api/TipoLineas
        [ResponseType(typeof(TipoLinea))]
        public IHttpActionResult PostTipoLinea(TipoLinea tipoLinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoLineas.Add(tipoLinea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoLinea.TipoLineaId }, tipoLinea);
        }

        // DELETE: api/TipoLineas/5
        [ResponseType(typeof(TipoLinea))]
        public IHttpActionResult DeleteTipoLinea(int id)
        {
            TipoLinea tipoLinea = db.TipoLineas.Find(id);
            if (tipoLinea == null)
            {
                return NotFound();
            }

            db.TipoLineas.Remove(tipoLinea);
            db.SaveChanges();

            return Ok(tipoLinea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoLineaExists(int id)
        {
            return db.TipoLineas.Count(e => e.TipoLineaId == id) > 0;
        }
    }
}