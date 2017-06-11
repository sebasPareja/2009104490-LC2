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
    public class DepartamentoesController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/Departamentoes
        public IQueryable<Departamento> Getdepartamento()
        {
            return db.departamento;
        }

        // GET: api/Departamentoes/5
        [ResponseType(typeof(Departamento))]
        public IHttpActionResult GetDepartamento(int id)
        {
            Departamento departamento = db.departamento.Find(id);
            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(departamento);
        }

        // PUT: api/Departamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartamento(int id, Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departamento.DepartamentoId)
            {
                return BadRequest();
            }

            db.Entry(departamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
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

        // POST: api/Departamentoes
        [ResponseType(typeof(Departamento))]
        public IHttpActionResult PostDepartamento(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.departamento.Add(departamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departamento.DepartamentoId }, departamento);
        }

        // DELETE: api/Departamentoes/5
        [ResponseType(typeof(Departamento))]
        public IHttpActionResult DeleteDepartamento(int id)
        {
            Departamento departamento = db.departamento.Find(id);
            if (departamento == null)
            {
                return NotFound();
            }

            db.departamento.Remove(departamento);
            db.SaveChanges();

            return Ok(departamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartamentoExists(int id)
        {
            return db.departamento.Count(e => e.DepartamentoId == id) > 0;
        }
    }
}