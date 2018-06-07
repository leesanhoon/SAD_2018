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
using TASI_APIHumanResoucre_Entities.Models;

namespace TASI_APIHumanResoucre_Entities.Controllers
{
    public class HumanResourceController : ApiController
    {
        private HumanResourceEntities db = new HumanResourceEntities();

        // GET: api/HumanResource
        public IQueryable<USER> GetUSERs()
        {
            return db.USERs;
        }

        // GET: api/HumanResource/5
        [ResponseType(typeof(USER))]
        public IHttpActionResult GetUSER(int id)
        {
            USER uSER = db.USERs.Find(id);
            if (uSER == null)
            {
                return NotFound();
            }

            return Ok(uSER);
        }

        // PUT: api/HumanResource/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSER(int id, USER uSER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSER.id)
            {
                return BadRequest();
            }

            db.Entry(uSER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERExists(id))
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

        // POST: api/HumanResource
        [ResponseType(typeof(USER))]
        public IHttpActionResult PostUSER(USER uSER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USERs.Add(uSER);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSER.id }, uSER);
        }

        // DELETE: api/HumanResource/5
        [ResponseType(typeof(USER))]
        public IHttpActionResult DeleteUSER(int id)
        {
            USER uSER = db.USERs.Find(id);
            if (uSER == null)
            {
                return NotFound();
            }

            db.USERs.Remove(uSER);
            db.SaveChanges();

            return Ok(uSER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USERExists(int id)
        {
            return db.USERs.Count(e => e.id == id) > 0;
        }
    }
}