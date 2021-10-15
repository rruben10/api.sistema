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
using api.sistema.Models;

namespace api.sistema.Controllers
{
    public class ventasController : ApiController
    {
        private sistemaEntities db = new sistemaEntities();

        // GET: api/ventas
        public IQueryable<ventas> Getventas()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.ventas;
        }

        // GET: api/ventas/5
        [ResponseType(typeof(ventas))]
        public IHttpActionResult Getventas(long id)
        {
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return NotFound();
            }

            return Ok(ventas);
        }

        // PUT: api/ventas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putventas(long id, ventas ventas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventas.id)
            {
                return BadRequest();
            }

            db.Entry(ventas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ventasExists(id))
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

        // POST: api/ventas
        [ResponseType(typeof(ventas))]
        public IHttpActionResult Postventas(ventas ventas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ventas.Add(ventas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ventas.id }, ventas);
        }

        // DELETE: api/ventas/5
        [ResponseType(typeof(ventas))]
        public IHttpActionResult Deleteventas(long id)
        {
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return NotFound();
            }

            db.ventas.Remove(ventas);
            db.SaveChanges();

            return Ok(ventas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ventasExists(long id)
        {
            return db.ventas.Count(e => e.id == id) > 0;
        }
    }
}