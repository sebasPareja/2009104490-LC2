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
    public class DistritoesController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/Distritoes
        public IQueryable<Distrito> Getdistrito()
        {
            return db.distrito;
        }

        // GET: api/Distritoes/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult GetDistrito(int id)
        {
            Distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(distrito);
        }

        // PUT: api/Distritoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistrito(int id, Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distrito.DistritoId)
            {
                return BadRequest();
            }

            db.Entry(distrito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(id))
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

        // POST: api/Distritoes
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult PostDistrito(Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.distrito.Add(distrito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = distrito.DistritoId }, distrito);
        }

        // DELETE: api/Distritoes/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult DeleteDistrito(int id)
        {
            Distrito distrito = db.distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            db.distrito.Remove(distrito);
            db.SaveChanges();

            return Ok(distrito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistritoExists(int id)
        {
            return db.distrito.Count(e => e.DistritoId == id) > 0;
        }
    }
}