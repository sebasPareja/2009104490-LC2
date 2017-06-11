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
    public class TrabajadorsController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/Trabajadors
        public IQueryable<Trabajador> Gettrabajador()
        {
            return db.trabajador;
        }

        // GET: api/Trabajadors/5
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult GetTrabajador(int id)
        {
            Trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }

        // PUT: api/Trabajadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrabajador(int id, Trabajador trabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabajador.TrabajadorId)
            {
                return BadRequest();
            }

            db.Entry(trabajador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajadorExists(id))
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

        // POST: api/Trabajadors
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult PostTrabajador(Trabajador trabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.trabajador.Add(trabajador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trabajador.TrabajadorId }, trabajador);
        }

        // DELETE: api/Trabajadors/5
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult DeleteTrabajador(int id)
        {
            Trabajador trabajador = db.trabajador.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            db.trabajador.Remove(trabajador);
            db.SaveChanges();

            return Ok(trabajador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrabajadorExists(int id)
        {
            return db.trabajador.Count(e => e.TrabajadorId == id) > 0;
        }
    }
}