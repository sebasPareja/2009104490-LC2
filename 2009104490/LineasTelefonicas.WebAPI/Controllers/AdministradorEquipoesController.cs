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
    public class AdministradorEquipoesController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/AdministradorEquipoes
        public IQueryable<AdministradorEquipo> GetadministradorEquipo()
        {
            return db.administradorEquipo;
        }

        // GET: api/AdministradorEquipoes/5
        [ResponseType(typeof(AdministradorEquipo))]
        public IHttpActionResult GetAdministradorEquipo(int id)
        {
            AdministradorEquipo administradorEquipo = db.administradorEquipo.Find(id);
            if (administradorEquipo == null)
            {
                return NotFound();
            }

            return Ok(administradorEquipo);
        }

        // PUT: api/AdministradorEquipoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministradorEquipo(int id, AdministradorEquipo administradorEquipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradorEquipo.AdministradorEquipoId)
            {
                return BadRequest();
            }

            db.Entry(administradorEquipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorEquipoExists(id))
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

        // POST: api/AdministradorEquipoes
        [ResponseType(typeof(AdministradorEquipo))]
        public IHttpActionResult PostAdministradorEquipo(AdministradorEquipo administradorEquipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.administradorEquipo.Add(administradorEquipo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administradorEquipo.AdministradorEquipoId }, administradorEquipo);
        }

        // DELETE: api/AdministradorEquipoes/5
        [ResponseType(typeof(AdministradorEquipo))]
        public IHttpActionResult DeleteAdministradorEquipo(int id)
        {
            AdministradorEquipo administradorEquipo = db.administradorEquipo.Find(id);
            if (administradorEquipo == null)
            {
                return NotFound();
            }

            db.administradorEquipo.Remove(administradorEquipo);
            db.SaveChanges();

            return Ok(administradorEquipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorEquipoExists(int id)
        {
            return db.administradorEquipo.Count(e => e.AdministradorEquipoId == id) > 0;
        }
    }
}