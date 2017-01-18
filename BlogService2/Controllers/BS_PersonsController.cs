using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BlogService2.Models;

namespace BlogService2.Controllers
{
    public class BS_PersonsController : ApiController
    {
        private BlogServiceContext db = new BlogServiceContext();

        // GET: api/BS_Persons
        public IQueryable<BS_Persons> GetBS_Persons()
        {
            return db.BS_Persons;
        }

        // GET: api/BS_Persons/5
        [ResponseType(typeof(BS_Persons))]
        public async Task<IHttpActionResult> GetBS_Persons(Guid id)
        {
            BS_Persons bS_Persons = await db.BS_Persons.FindAsync(id);
            if (bS_Persons == null)
            {
                return NotFound();
            }

            return Ok(bS_Persons);
        }

        // PUT: api/BS_Persons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBS_Persons(Guid id, BS_Persons bS_Persons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bS_Persons.Id)
            {
                return BadRequest();
            }

            db.Entry(bS_Persons).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BS_PersonsExists(id))
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

        // POST: api/BS_Persons
        [ResponseType(typeof(BS_Persons))]
        public async Task<IHttpActionResult> PostBS_Persons(BS_Persons bS_Persons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BS_Persons.Add(bS_Persons);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BS_PersonsExists(bS_Persons.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bS_Persons.Id }, bS_Persons);
        }

        // DELETE: api/BS_Persons/5
        [ResponseType(typeof(BS_Persons))]
        public async Task<IHttpActionResult> DeleteBS_Persons(Guid id)
        {
            BS_Persons bS_Persons = await db.BS_Persons.FindAsync(id);
            if (bS_Persons == null)
            {
                return NotFound();
            }

            db.BS_Persons.Remove(bS_Persons);
            await db.SaveChangesAsync();

            return Ok(bS_Persons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BS_PersonsExists(Guid id)
        {
            return db.BS_Persons.Count(e => e.Id == id) > 0;
        }
    }
}