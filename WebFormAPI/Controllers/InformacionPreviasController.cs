using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestApi;

namespace RestApi.Controllers
{
    public class InformacionPreviasController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/InformacionPrevias
        public IQueryable<InformacionPrevia> GetInformacionPrevias()
        {
            return db.InformacionPrevias;
        }

        // GET: api/InformacionPrevias/5
        [ResponseType(typeof(InformacionPrevia))]
        public IHttpActionResult GetInformacionPrevia(int id)
        {
            InformacionPrevia informacionPrevia = db.InformacionPrevias.Find(id);
            if (informacionPrevia == null)
            {
                return NotFound();
            }

            return Ok(informacionPrevia);
        }

        // GET: api/InformacionPrevias/R1234
        [ResponseType(typeof(InformacionPrevia))]
        public IHttpActionResult GetInformacionPrevia(string ROL, Boolean RecuperarDocumento)
        {

            InformacionPrevia informacionPrevia = db.InformacionPrevias.SingleOrDefault(x => x.ROL == ROL);

            if (informacionPrevia == null)
            {
                return NotFound();
            }

            if (RecuperarDocumento)
            {
                string archivo = ConfigurationManager.AppSettings["archivo_previas"];

                informacionPrevia.documento = File.ReadAllBytes(archivo);
            }
            return Ok(informacionPrevia);
        }


        // PUT: api/InformacionPrevias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInformacionPrevia(int id, InformacionPrevia informacionPrevia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != informacionPrevia.ID)
            {
                return BadRequest();
            }

            db.Entry(informacionPrevia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacionPreviaExists(id))
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

        // POST: api/InformacionPrevias
        [ResponseType(typeof(InformacionPrevia))]
        public IHttpActionResult PostInformacionPrevia(InformacionPrevia informacionPrevia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InformacionPrevias.Add(informacionPrevia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = informacionPrevia.ID }, informacionPrevia);
        }

        // DELETE: api/InformacionPrevias/5
        [ResponseType(typeof(InformacionPrevia))]
        public IHttpActionResult DeleteInformacionPrevia(int id)
        {
            InformacionPrevia informacionPrevia = db.InformacionPrevias.Find(id);
            if (informacionPrevia == null)
            {
                return NotFound();
            }

            db.InformacionPrevias.Remove(informacionPrevia);
            db.SaveChanges();

            return Ok(informacionPrevia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InformacionPreviaExists(int id)
        {
            return db.InformacionPrevias.Count(e => e.ID == id) > 0;
        }
    }
}