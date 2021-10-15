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
    public class configuracionsController : ApiController
    {
        private sistemaEntities db = new sistemaEntities();

        // GET: api/configuracions
        public IQueryable<configuracion> Getconfiguracion()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.configuracion;
        }

        // GET: api/configuracions/5
        [ResponseType(typeof(configuracion))]
        public IHttpActionResult Getconfiguracion(long id)
        {
            configuracion configuracion = db.configuracion.Find(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            return Ok(configuracion);
        }

        // PUT: api/configuracions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putconfiguracion(long id, configuracion configuracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuracion.id)
            {
                return BadRequest();
            }

            db.Entry(configuracion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!configuracionExists(id))
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

        // POST: api/configuracions
        [ResponseType(typeof(configuracion))]
        public IHttpActionResult Postconfiguracion(configuracion configuracion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.configuracion.Add(configuracion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = configuracion.id }, configuracion);
        }

        // DELETE: api/configuracions/5
        [ResponseType(typeof(configuracion))]
        public IHttpActionResult Deleteconfiguracion(long id)
        {
            configuracion configuracion = db.configuracion.Find(id);
            if (configuracion == null)
            {
                return NotFound();
            }

            db.configuracion.Remove(configuracion);
            db.SaveChanges();

            return Ok(configuracion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool configuracionExists(long id)
        {
            return db.configuracion.Count(e => e.id == id) > 0;
        }
    }
}