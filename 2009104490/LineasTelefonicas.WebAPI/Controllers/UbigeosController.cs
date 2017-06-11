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
    public class UbigeosController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/Ubigeos
        public IQueryable<Ubigeo> Getubigeo()
        {
            return db.ubigeo;
        }

        // GET: api/Ubigeos/5
        [ResponseType(typeof(Ubigeo))]
        public IHttpActionResult GetUbigeo(int id)
        {
            Ubigeo ubigeo = db.ubigeo.Find(id);
            if (ubigeo == null)
            {
                return NotFound();
            }

            return Ok(ubigeo);
        }

        // PUT: api/Ubigeos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUbigeo(int id, Ubigeo ubigeo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ubigeo.UbigeoId)
            {
                return BadRequest();
            }

            db.Entry(ubigeo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbigeoExists(id))
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

        // POST: api/Ubigeos
        [ResponseType(typeof(Ubigeo))]
        public IHttpActionResult PostUbigeo(Ubigeo ubigeo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ubigeo.Add(ubigeo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ubigeo.UbigeoId }, ubigeo);
        }

        // DELETE: api/Ubigeos/5
        [ResponseType(typeof(Ubigeo))]
        public IHttpActionResult DeleteUbigeo(int id)
        {
            Ubigeo ubigeo = db.ubigeo.Find(id);
            if (ubigeo == null)
            {
                return NotFound();
            }

            db.ubigeo.Remove(ubigeo);
            db.SaveChanges();

            return Ok(ubigeo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UbigeoExists(int id)
        {
            return db.ubigeo.Count(e => e.UbigeoId == id) > 0;
        }
    }
}