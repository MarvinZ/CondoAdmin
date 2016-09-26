using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Condo: Audit
    {
        virtual public int Id { get; set; }
        virtual public string  Name { get; set; }
        virtual public decimal Balance { get; set; }
        virtual public ICollection<Member> Members { get; set; }

      

    }
}
