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
using RestAPI;
using RestApi;

namespace RestAPI.Controllers
{
    public class FactibilidadesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Factibilidades
        public IQueryable<Factibilidad> GetFactibilidads()
        {
            return db.Factibilidades;
        }

        // GET: api/Factibilidades/5
        [ResponseType(typeof(Factibilidad))]
        public IHttpActionResult GetFactibilidad(int id)
        {
            Factibilidad factibilidad = db.Factibilidades.Find(id);
            if (factibilidad == null)
            {
                return NotFound();
            }

            return Ok(factibilidad);
        }

        // GET: api/Factibilidades/?rol=R1234
        [ResponseType(typeof(Factibilidad))]
        public IHttpActionResult GetFactibilidad(string ROL)
        {
            Factibilidad factibilidad = db.Factibilidades.SingleOrDefault(x => x.ROL.Equals(ROL));
            if (factibilidad == null)
            {
                return NotFound();
            }

            return Ok(factibilidad);
        }

        // PUT: api/Factibilidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactibilidad(int id, Factibilidad factibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factibilidad.ID)
            {
                return BadRequest();
            }

            db.Entry(factibilidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactibilidadExists(id))
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

        // POST: api/Factibilidades
        [ResponseType(typeof(Factibilidad))]
        public IHttpActionResult PostFactibilidad(Factibilidad factibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Factibilidades.Add(factibilidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factibilidad.ID }, factibilidad);
        }

        // DELETE: api/Factibilidades/5
        [ResponseType(typeof(Factibilidad))]
        public IHttpActionResult DeleteFactibilidad(int id)
        {
            Factibilidad factibilidad = db.Factibilidades.Find(id);
            if (factibilidad == null)
            {
                return NotFound();
            }

            db.Factibilidades.Remove(factibilidad);
            db.SaveChanges();

            return Ok(factibilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FactibilidadExists(int id)
        {
            return db.Factibilidades.Count(e => e.ID == id) > 0;
        }
    }
}