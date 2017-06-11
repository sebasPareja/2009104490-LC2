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
    public class EstadoEvaluacionsController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/EstadoEvaluacions
        public IQueryable<EstadoEvaluacion> GetEstadoEvaluacions()
        {
            return db.EstadoEvaluacions;
        }

        // GET: api/EstadoEvaluacions/5
        [ResponseType(typeof(EstadoEvaluacion))]
        public IHttpActionResult GetEstadoEvaluacion(int id)
        {
            EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            if (estadoEvaluacion == null)
            {
                return NotFound();
            }

            return Ok(estadoEvaluacion);
        }

        // PUT: api/EstadoEvaluacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadoEvaluacion(int id, EstadoEvaluacion estadoEvaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoEvaluacion.EstadoEvaluacionId)
            {
                return BadRequest();
            }

            db.Entry(estadoEvaluacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoEvaluacionExists(id))
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

        // POST: api/EstadoEvaluacions
        [ResponseType(typeof(EstadoEvaluacion))]
        public IHttpActionResult PostEstadoEvaluacion(EstadoEvaluacion estadoEvaluacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadoEvaluacions.Add(estadoEvaluacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadoEvaluacion.EstadoEvaluacionId }, estadoEvaluacion);
        }

        // DELETE: api/EstadoEvaluacions/5
        [ResponseType(typeof(EstadoEvaluacion))]
        public IHttpActionResult DeleteEstadoEvaluacion(int id)
        {
            EstadoEvaluacion estadoEvaluacion = db.EstadoEvaluacions.Find(id);
            if (estadoEvaluacion == null)
            {
                return NotFound();
            }

            db.EstadoEvaluacions.Remove(estadoEvaluacion);
            db.SaveChanges();

            return Ok(estadoEvaluacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoEvaluacionExists(int id)
        {
            return db.EstadoEvaluacions.Count(e => e.EstadoEvaluacionId == id) > 0;
        }
    }
}