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
    public class MembersController : ApiController
    {
        private Context db = new Context();

        // GET: api/Members
        //public IQueryable<Member> GetMembers()
        //{
        //    return db.Members;
        //}
        // GET: api/Members/5
        [ResponseType(typeof(List<MemberDTO>))]
        public IHttpActionResult GetMembersByCondoId(int id)
        {
            var members = db.Members.Where(e => e.CondoId == id);
            if (!members.Any())
            {
                return NotFound();
            }

            var result = members.Select(member => new MemberDTO()
            {
                Id = member.Id,
                Balance = member.Balance,
                Name = member.Name,
                Status = member.Status.Name

            }).ToList();
            return Ok(result);
        }

        //// GET: api/Members/5
        //[ResponseType(typeof(Member))]
        //public IHttpActionResult GetMember(int id)
        //{
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(member);
        //}

        //// PUT: api/Members/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMember(int id, Member member)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != member.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(member).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MemberExists(id))
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

        //// POST: api/Members
        //[ResponseType(typeof(Member))]
        //public IHttpActionResult PostMember(Member member)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Members.Add(member);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = member.Id }, member);
        //}

        //// DELETE: api/Members/5
        //[ResponseType(typeof(Member))]
        //public IHttpActionResult DeleteMember(int id)
        //{
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Members.Remove(member);
        //    db.SaveChanges();

        //    return Ok(member);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(int id)
        {
            return db.Members.Count(e => e.Id == id) > 0;
        }

        public class MemberDTO
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
          //  public virtual ICollection<Person> Representatives { get; set; }
            public virtual decimal Balance { get; set; }
            public virtual string Status { get; set; }
           // public virtual ICollection<MemberPerson> MemberPeople { get; set; }
        }

    }
}
