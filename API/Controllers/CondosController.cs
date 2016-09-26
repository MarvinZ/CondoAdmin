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
using POCO;
using REPO;

namespace API.Controllers
{
    public class CondosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Condos
        //public IQueryable<Condo> GetCondos()
        //{
        //    return db.Condos;
        //}
        public IHttpActionResult GetCondos()
        {

            var condos = db.Condos;
            if (condos == null)
            {
                return NotFound();
            }
            var result = condos.Select(condo => new CondoDTO()
            {
                Id = condo.Id, Name = condo.Name, Balance = condo.Balance
            }).ToList();

            return Ok(result);
        }

        //// GET: api/Condos/5
        //[ResponseType(typeof(Condo))]
        //public IHttpActionResult GetCondo(int id)
        //{
        //    Condo condo = db.Condos.Find(id);
        //    if (condo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(condo);
        //}

        //// PUT: api/Condos/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCondo(int id, Condo condo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != condo.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(condo).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CondoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Condos
        //[ResponseType(typeof(Condo))]
        //public IHttpActionResult PostCondo(Condo condo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Condos.Add(condo);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = condo.Id }, condo);
        //}

        //// DELETE: api/Condos/5
        //[ResponseType(typeof(Condo))]
        //public IHttpActionResult DeleteCondo(int id)
        //{
        //    Condo condo = db.Condos.Find(id);
        //    if (condo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Condos.Remove(condo);
        //    db.SaveChanges();

        //    return Ok(condo);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondoExists(int id)
        {
            return db.Condos.Count(e => e.Id == id) > 0;
        }

        public class CondoDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public decimal Balance { get; set; }
        }
    }
}