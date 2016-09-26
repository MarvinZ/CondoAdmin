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
    public class CondoTransactionsController : ApiController
    {
        private Context db = new Context();

        [ResponseType(typeof(List<CondoTransactionDTO>))]
        public IHttpActionResult GetTransactionsByCondoId(int id)
        {
            var transactions = db.CondoTransactions.Where(e => e.CondoId == id);
            if (!transactions.Any())
            {
                return NotFound();
            }

            var result = transactions.Select(transaction => new CondoTransactionDTO()
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Description = transaction.Description,
                TransactionDateTime = transaction.TransactionDateTime,
                TransactionType = transaction.CondoTransactionType.Name

            }).ToList();
            return Ok(result);
        }

        // POST: api/Transactions
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult CreatePayment(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            transaction.TransactionTypeId = 2;
            transaction.CreateDatetime = DateTime.Now;
            transaction.TransactionDateTime = DateTime.Now;

            db.Transactions.Add(transaction);
            db.SaveChanges();
            //update balance
            var me = db.Members.SingleOrDefault(e => e.Id == transaction.MemberId);
            if (me == null) return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
            me.Balance += transaction.Amount;
            db.SaveChanges();
            //update status
            if (me.Balance > 0)
            {
                me.StatusId = 1;
                db.SaveChanges();
            }
            else
            {
                me.StatusId = 2;
                db.SaveChanges();
            }
            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
        }
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult CreateCharge(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            transaction.TransactionTypeId = 1;
            transaction.CreateDatetime = DateTime.Now;
            transaction.TransactionDateTime = DateTime.Now;

            db.Transactions.Add(transaction);
            db.SaveChanges();
            //update balance
            var me = db.Members.SingleOrDefault(e => e.Id == transaction.MemberId);
            if (me == null) return CreatedAtRoute("DefaultApi", new {id = transaction.Id}, transaction);
            me.Balance -= transaction.Amount;
            db.SaveChanges();
            //update status
            if (me.Balance > 0)
            {
                me.StatusId = 1;
                db.SaveChanges();
            }
            else
            {
                me.StatusId = 2;
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
        }


     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionExists(int id)
        {
            return db.Transactions.Count(e => e.Id == id) > 0;
        }
    }
    public class CondoTransactionDTO
    {
        virtual public int Id { get; set; }
        //virtual public int MemberId { get; set; }
        //virtual public Member Member { get; set; }
        virtual public string TransactionType { get; set; }
        //  virtual public TransactionType TransactionType { get; set; }
        virtual public decimal Amount { get; set; }
        virtual public DateTime TransactionDateTime { get; set; }
        virtual public string Description { get; set; }

        virtual public string CreatedBy { get; set; }
    }
    
}