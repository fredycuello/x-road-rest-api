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
    public class PropiedadesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Propiedades
        public IQueryable<Propiedad> GetPropiedads()
        {
            return db.Propiedads;
        }

        // GET: api/Propiedades/5
        [ResponseType(typeof(Propiedad))]
        public IHttpActionResult GetPropiedad(int id)
        {
            Propiedad propiedad = db.Propiedads.Find(id);
            if (propiedad == null)
            {
                return NotFound();
            }

            return Ok(propiedad);
        }

        // GET: api/Propiedades/?rol=1234
        [ResponseType(typeof(Propiedad))]
        public IHttpActionResult GetPropiedad(string ROL)
        {
            Propiedad propiedad = db.Propiedads.SingleOrDefault(x => x.ROL == ROL);

            if (propiedad == null)
            {
                return NotFound();
            }

            return Ok(propiedad);
        }

        // PUT: api/Propiedades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPropiedad(int id, Propiedad propiedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propiedad.ID)
            {
                return BadRequest();
            }

            db.Entry(propiedad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropiedadExists(id))
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

        // POST: api/Propiedades
        [ResponseType(typeof(Propiedad))]
        public IHttpActionResult PostPropiedad(Propiedad propiedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Propiedads.Add(propiedad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = propiedad.ID }, propiedad);
        }

        // DELETE: api/Propiedades/5
        [ResponseType(typeof(Propiedad))]
        public IHttpActionResult DeletePropiedad(int id)
        {
            Propiedad propiedad = db.Propiedads.Find(id);
            if (propiedad == null)
            {
                return NotFound();
            }

            db.Propiedads.Remove(propiedad);
            db.SaveChanges();

            return Ok(propiedad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropiedadExists(int id)
        {
            return db.Propiedads.Count(e => e.ID == id) > 0;
        }
    }
}