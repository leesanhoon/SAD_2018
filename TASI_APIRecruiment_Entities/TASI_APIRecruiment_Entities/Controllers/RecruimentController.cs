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
using TASI_APIRecruiment_Entities.Models;

namespace TASI_APIRecruiment_Entities.Controllers
{
    public class RecruimentController : ApiController
    {
        private RecruimentEntities db = new RecruimentEntities();

        // GET: api/Recruiment
        public IQueryable<CANDIDATE> GetCANDIDATEs()
        {
            return db.CANDIDATEs;
        }

        // GET: api/Recruiment/5
        [ResponseType(typeof(CANDIDATE))]
        public IHttpActionResult GetCANDIDATE(int id)
        {
            CANDIDATE cANDIDATE = db.CANDIDATEs.Find(id);
            if (cANDIDATE == null)
            {
                return NotFound();
            }

            return Ok(cANDIDATE);
        }

        // PUT: api/Recruiment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCANDIDATE(int id, CANDIDATE cANDIDATE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cANDIDATE.id)
            {
                return BadRequest();
            }

            db.Entry(cANDIDATE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CANDIDATEExists(id))
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

        // POST: api/Recruiment
        [ResponseType(typeof(CANDIDATE))]
        public IHttpActionResult PostCANDIDATE(CANDIDATE cANDIDATE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CANDIDATEs.Add(cANDIDATE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cANDIDATE.id }, cANDIDATE);
        }

        // DELETE: api/Recruiment/5
        [ResponseType(typeof(CANDIDATE))]
        public IHttpActionResult DeleteCANDIDATE(int id)
        {
            CANDIDATE cANDIDATE = db.CANDIDATEs.Find(id);
            if (cANDIDATE == null)
            {
                return NotFound();
            }

            db.CANDIDATEs.Remove(cANDIDATE);
            db.SaveChanges();

            return Ok(cANDIDATE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CANDIDATEExists(int id)
        {
            return db.CANDIDATEs.Count(e => e.id == id) > 0;
        }
    }
}