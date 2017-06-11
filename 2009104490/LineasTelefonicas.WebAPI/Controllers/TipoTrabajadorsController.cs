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
    public class TipoTrabajadorsController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/TipoTrabajadors
        public IQueryable<TipoTrabajador> GetTipoTrabajadors()
        {
            return db.TipoTrabajadors;
        }

        // GET: api/TipoTrabajadors/5
        [ResponseType(typeof(TipoTrabajador))]
        public IHttpActionResult GetTipoTrabajador(int id)
        {
            TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            if (tipoTrabajador == null)
            {
                return NotFound();
            }

            return Ok(tipoTrabajador);
        }

        // PUT: api/TipoTrabajadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoTrabajador(int id, TipoTrabajador tipoTrabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoTrabajador.TipoTrabajadorId)
            {
                return BadRequest();
            }

            db.Entry(tipoTrabajador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTrabajadorExists(id))
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

        // POST: api/TipoTrabajadors
        [ResponseType(typeof(TipoTrabajador))]
        public IHttpActionResult PostTipoTrabajador(TipoTrabajador tipoTrabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoTrabajadors.Add(tipoTrabajador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoTrabajador.TipoTrabajadorId }, tipoTrabajador);
        }

        // DELETE: api/TipoTrabajadors/5
        [ResponseType(typeof(TipoTrabajador))]
        public IHttpActionResult DeleteTipoTrabajador(int id)
        {
            TipoTrabajador tipoTrabajador = db.TipoTrabajadors.Find(id);
            if (tipoTrabajador == null)
            {
                return NotFound();
            }

            db.TipoTrabajadors.Remove(tipoTrabajador);
            db.SaveChanges();

            return Ok(tipoTrabajador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoTrabajadorExists(int id)
        {
            return db.TipoTrabajadors.Count(e => e.TipoTrabajadorId == id) > 0;
        }
    }
}