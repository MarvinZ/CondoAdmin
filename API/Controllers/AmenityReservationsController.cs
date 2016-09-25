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
    public class AmenityReservationsController : ApiController
    {
        private Context db = new Context();

        // GET: api/AmenityReservations
        //public IQueryable<AmenityReservation> GetAmenityReservations()
        //{
        //    return db.AmenityReservations;
        //}
        public IHttpActionResult GetAllReservations()
        {

            var reservations = db.AmenityReservations;
            if (reservations == null)
            {
                return NotFound();
            }
            var result = reservations.Select(rsv => new ReservationDTO()
            {
                Id = rsv.Id,
                Amenity = rsv.Amenity.Name,
                Member = rsv.MemberId.ToString(),
                Person = rsv.Person.FirstName+" "+rsv.Person.LastName,
                StartDateTime = rsv.StartTime,
                EndDateTime = rsv.EndDatetime,
                Status = rsv.AmenityReservationStatus.Name

            }).ToList();

            return Ok(result);
        }

        // GET: api/AmenityReservations/5
        [ResponseType(typeof(AmenityReservation))]
        public IHttpActionResult GetAmenityReservation(int id)
        {
            AmenityReservation amenityReservation = db.AmenityReservations.Find(id);
            if (amenityReservation == null)
            {
                return NotFound();
            }

            return Ok(amenityReservation);
        }

        // PUT: api/AmenityReservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmenityReservation(int id, AmenityReservation amenityReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amenityReservation.Id)
            {
                return BadRequest();
            }

            db.Entry(amenityReservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityReservationExists(id))
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

        // POST: api/AmenityReservations
        [ResponseType(typeof(AmenityReservation))]
        public IHttpActionResult PostAmenityReservation(AmenityReservation amenityReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AmenityReservations.Add(amenityReservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = amenityReservation.Id }, amenityReservation);
        }

        // DELETE: api/AmenityReservations/5
        [ResponseType(typeof(AmenityReservation))]
        public IHttpActionResult DeleteAmenityReservation(int id)
        {
            AmenityReservation amenityReservation = db.AmenityReservations.Find(id);
            if (amenityReservation == null)
            {
                return NotFound();
            }

            db.AmenityReservations.Remove(amenityReservation);
            db.SaveChanges();

            return Ok(amenityReservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmenityReservationExists(int id)
        {
            return db.AmenityReservations.Count(e => e.Id == id) > 0;
        }
    }

    public class ReservationDTO
    {
        public int Id { get; set; }
        public string Amenity { get; set; }
        public string Member { get; set; }
        public string Person { get; set; }
        public string Status { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}