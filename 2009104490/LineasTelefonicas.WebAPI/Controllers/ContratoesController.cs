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
    public class ContratoesController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/Contratoes
        public IQueryable<Contrato> Getcontrato()
        {
            return db.contrato;
        }

        // GET: api/Contratoes/5
        [ResponseType(typeof(Contrato))]
        public IHttpActionResult GetContrato(int id)
        {
            Contrato contrato = db.contrato.Find(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // PUT: api/Contratoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContrato(int id, Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contrato.ContratoId)
            {
                return BadRequest();
            }

            db.Entry(contrato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
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

        // POST: api/Contratoes
        [ResponseType(typeof(Contrato))]
        public IHttpActionResult PostContrato(Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contrato.Add(contrato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contrato.ContratoId }, contrato);
        }

        // DELETE: api/Contratoes/5
        [ResponseType(typeof(Contrato))]
        public IHttpActionResult DeleteContrato(int id)
        {
            Contrato contrato = db.contrato.Find(id);
            if (contrato == null)
            {
                return NotFound();
            }

            db.contrato.Remove(contrato);
            db.SaveChanges();

            return Ok(contrato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContratoExists(int id)
        {
            return db.contrato.Count(e => e.ContratoId == id) > 0;
        }
    }
}