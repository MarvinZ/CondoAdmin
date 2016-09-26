using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class CondoTransaction : Audit
    {
        virtual public int Id { get; set; }
        virtual public int CondoId { get; set; }
        virtual public Condo Condo { get; set; }
        virtual public int CondoTransactionTypeId { get; set; }
        virtual public CondoTransactionType CondoTransactionType { get; set; }
        virtual public decimal Amount { get; set; }
        virtual public DateTime TransactionDateTime { get; set; }
        virtual public string Description { get; set; }
    }
}
