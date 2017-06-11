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
    public class LineaTelefonicasController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/LineaTelefonicas
        public IQueryable<LineaTelefonica.Entities.Entities.LineaTelefonica> Getlineatelefonica()
        {
            return db.lineatelefonica;
        }

        // GET: api/LineaTelefonicas/5
        [ResponseType(typeof(LineaTelefonica.Entities.Entities.LineaTelefonica))]
        public IHttpActionResult GetLineaTelefonica(int id)
        {
            LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica = db.lineatelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return NotFound();
            }

            return Ok(lineaTelefonica);
        }

        // PUT: api/LineaTelefonicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineaTelefonica(int id, LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineaTelefonica.LineaTelefonicaId)
            {
                return BadRequest();
            }

            db.Entry(lineaTelefonica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaTelefonicaExists(id))
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

        // POST: api/LineaTelefonicas
        [ResponseType(typeof(LineaTelefonica.Entities.Entities.LineaTelefonica))]
        public IHttpActionResult PostLineaTelefonica(LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.lineatelefonica.Add(lineaTelefonica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lineaTelefonica.LineaTelefonicaId }, lineaTelefonica);
        }

        // DELETE: api/LineaTelefonicas/5
        [ResponseType(typeof(LineaTelefonica.Entities.Entities.LineaTelefonica))]
        public IHttpActionResult DeleteLineaTelefonica(int id)
        {
            LineaTelefonica.Entities.Entities.LineaTelefonica lineaTelefonica = db.lineatelefonica.Find(id);
            if (lineaTelefonica == null)
            {
                return NotFound();
            }

            db.lineatelefonica.Remove(lineaTelefonica);
            db.SaveChanges();

            return Ok(lineaTelefonica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaTelefonicaExists(int id)
        {
            return db.lineatelefonica.Count(e => e.LineaTelefonicaId == id) > 0;
        }
    }
}