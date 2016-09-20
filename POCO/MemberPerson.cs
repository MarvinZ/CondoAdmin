using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class MemberPerson : Audit
    {
        virtual public int Id { get; set; }
        virtual public int MemberId { get; set; }
        virtual public Member Member { get; set; }
        virtual public int PersonId { get; set; }
        virtual public Person Person { get; set; }


    }
}
