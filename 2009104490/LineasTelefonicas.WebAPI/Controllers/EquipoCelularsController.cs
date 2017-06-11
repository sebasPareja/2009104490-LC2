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
    public class EquipoCelularsController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/EquipoCelulars
        public IQueryable<EquipoCelular> Getequipocelular()
        {
            return db.equipocelular;
        }

        // GET: api/EquipoCelulars/5
        [ResponseType(typeof(EquipoCelular))]
        public IHttpActionResult GetEquipoCelular(int id)
        {
            EquipoCelular equipoCelular = db.equipocelular.Find(id);
            if (equipoCelular == null)
            {
                return NotFound();
            }

            return Ok(equipoCelular);
        }

        // PUT: api/EquipoCelulars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquipoCelular(int id, EquipoCelular equipoCelular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipoCelular.EquipoCelularId)
            {
                return BadRequest();
            }

            db.Entry(equipoCelular).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoCelularExists(id))
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

        // POST: api/EquipoCelulars
        [ResponseType(typeof(EquipoCelular))]
        public IHttpActionResult PostEquipoCelular(EquipoCelular equipoCelular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.equipocelular.Add(equipoCelular);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipoCelular.EquipoCelularId }, equipoCelular);
        }

        // DELETE: api/EquipoCelulars/5
        [ResponseType(typeof(EquipoCelular))]
        public IHttpActionResult DeleteEquipoCelular(int id)
        {
            EquipoCelular equipoCelular = db.equipocelular.Find(id);
            if (equipoCelular == null)
            {
                return NotFound();
            }

            db.equipocelular.Remove(equipoCelular);
            db.SaveChanges();

            return Ok(equipoCelular);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquipoCelularExists(int id)
        {
            return db.equipocelular.Count(e => e.EquipoCelularId == id) > 0;
        }
    }
}