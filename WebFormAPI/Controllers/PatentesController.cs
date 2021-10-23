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
using RestApi;

namespace RestApi.Controllers
{
    public class PatentesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Patentes
        public IQueryable<Patente> GetPatentes()
        {
            return db.Patentes;
        }

        // GET: api/Patentes/5
        [ResponseType(typeof(Patente))]
        public IHttpActionResult GetPatente(int id)
        {
            Patente patente = db.Patentes.Find(id);
            if (patente == null)
            {
                return NotFound();
            }

            return Ok(patente);
        }

        // GET: api/Patentes/5
        [ResponseType(typeof(Patente))]
        public IHttpActionResult GetPatente(string RUT)
        {
            Patente patente = db.Patentes.SingleOrDefault(x => x.RUT.Equals(RUT));
            if (patente == null)
            {
                return NotFound();
            }

            return Ok(patente);
        }

        // PUT: api/Patentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatente(int id, Patente patente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patente.ID)
            {
                return BadRequest();
            }

            db.Entry(patente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatenteExists(id))
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

        // POST: api/Patentes
        [ResponseType(typeof(Patente))]
        public IHttpActionResult PostPatente(Patente patente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patentes.Add(patente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patente.ID }, patente);
        }

        // DELETE: api/Patentes/5
        [ResponseType(typeof(Patente))]
        public IHttpActionResult DeletePatente(int id)
        {
            Patente patente = db.Patentes.Find(id);
            if (patente == null)
            {
                return NotFound();
            }

            db.Patentes.Remove(patente);
            db.SaveChanges();

            return Ok(patente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatenteExists(int id)
        {
            return db.Patentes.Count(e => e.ID == id) > 0;
        }
    }
}