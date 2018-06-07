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
    public class HumanResourcesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/HumanResources
        public IQueryable<HumanResource> GetHumanResources()
        {
            return db.HumanResources;
        }

        // GET: api/HumanResources/5
        [ResponseType(typeof(HumanResource))]
        public IHttpActionResult GetHumanResource(int id)
        {
            HumanResource humanResource = db.HumanResources.Find(id);
            if (humanResource == null)
            {
                return NotFound();
            }

            return Ok(humanResource);
        }

        // PUT: api/HumanResources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHumanResource(int id, HumanResource humanResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != humanResource.Id)
            {
                return BadRequest();
            }

            db.Entry(humanResource).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanResourceExists(id))
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

        // POST: api/HumanResources
        [ResponseType(typeof(HumanResource))]
        public IHttpActionResult PostHumanResource(HumanResource humanResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HumanResources.Add(humanResource);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = humanResource.Id }, humanResource);
        }

        // DELETE: api/HumanResources/5
        [ResponseType(typeof(HumanResource))]
        public IHttpActionResult DeleteHumanResource(int id)
        {
            HumanResource humanResource = db.HumanResources.Find(id);
            if (humanResource == null)
            {
                return NotFound();
            }

            db.HumanResources.Remove(humanResource);
            db.SaveChanges();

            return Ok(humanResource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HumanResourceExists(int id)
        {
            return db.HumanResources.Count(e => e.Id == id) > 0;
        }
    }
}