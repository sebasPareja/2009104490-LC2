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
    public class AdministradorLineasController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/AdministradorLineas
        public IQueryable<AdministradorLinea> GetadministradorLinea()
        {
            return db.administradorLinea;
        }

        // GET: api/AdministradorLineas/5
        [ResponseType(typeof(AdministradorLinea))]
        public IHttpActionResult GetAdministradorLinea(int id)
        {
            AdministradorLinea administradorLinea = db.administradorLinea.Find(id);
            if (administradorLinea == null)
            {
                return NotFound();
            }

            return Ok(administradorLinea);
        }

        // PUT: api/AdministradorLineas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministradorLinea(int id, AdministradorLinea administradorLinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradorLinea.AdministradorLineaId)
            {
                return BadRequest();
            }

            db.Entry(administradorLinea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorLineaExists(id))
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

        // POST: api/AdministradorLineas
        [ResponseType(typeof(AdministradorLinea))]
        public IHttpActionResult PostAdministradorLinea(AdministradorLinea administradorLinea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.administradorLinea.Add(administradorLinea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administradorLinea.AdministradorLineaId }, administradorLinea);
        }

        // DELETE: api/AdministradorLineas/5
        [ResponseType(typeof(AdministradorLinea))]
        public IHttpActionResult DeleteAdministradorLinea(int id)
        {
            AdministradorLinea administradorLinea = db.administradorLinea.Find(id);
            if (administradorLinea == null)
            {
                return NotFound();
            }

            db.administradorLinea.Remove(administradorLinea);
            db.SaveChanges();

            return Ok(administradorLinea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorLineaExists(int id)
        {
            return db.administradorLinea.Count(e => e.AdministradorLineaId == id) > 0;
        }
    }
}