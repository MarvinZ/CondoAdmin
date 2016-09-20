using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Transaction : Audit
    {
        virtual public int Id { get; set; }

        virtual public int MemberId { get; set; }
        virtual public Member Member { get; set; }
        virtual public int TransactionTypeId { get; set; }
        virtual public TransactionType TransactionType { get; set; }
        virtual public decimal Amount { get; set; }
        virtual public DateTime TransactionDateTime { get; set; }
        virtual public string Description { get; set; }
    }
}
