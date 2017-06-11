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
    public class TipoPlansController : ApiController
    {
        private LineaTelefonicaDbContext db = new LineaTelefonicaDbContext();

        // GET: api/TipoPlans
        public IQueryable<TipoPlan> GetTipoPlans()
        {
            return db.TipoPlans;
        }

        // GET: api/TipoPlans/5
        [ResponseType(typeof(TipoPlan))]
        public IHttpActionResult GetTipoPlan(int id)
        {
            TipoPlan tipoPlan = db.TipoPlans.Find(id);
            if (tipoPlan == null)
            {
                return NotFound();
            }

            return Ok(tipoPlan);
        }

        // PUT: api/TipoPlans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoPlan(int id, TipoPlan tipoPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoPlan.TipoPlanId)
            {
                return BadRequest();
            }

            db.Entry(tipoPlan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPlanExists(id))
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

        // POST: api/TipoPlans
        [ResponseType(typeof(TipoPlan))]
        public IHttpActionResult PostTipoPlan(TipoPlan tipoPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoPlans.Add(tipoPlan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoPlan.TipoPlanId }, tipoPlan);
        }

        // DELETE: api/TipoPlans/5
        [ResponseType(typeof(TipoPlan))]
        public IHttpActionResult DeleteTipoPlan(int id)
        {
            TipoPlan tipoPlan = db.TipoPlans.Find(id);
            if (tipoPlan == null)
            {
                return NotFound();
            }

            db.TipoPlans.Remove(tipoPlan);
            db.SaveChanges();

            return Ok(tipoPlan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoPlanExists(int id)
        {
            return db.TipoPlans.Count(e => e.TipoPlanId == id) > 0;
        }
    }
}