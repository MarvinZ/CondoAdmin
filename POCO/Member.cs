using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Member: Audit
    {
        virtual public int Id { get; set; }
        virtual public int CondoId { get; set; }
        virtual public Condo Condo { get; set; }
        virtual public string  Name { get; set; }
        virtual public ICollection<Person> Representatives { get; set; }
        virtual public decimal Balance { get; set; }
        virtual public int StatusId { get; set; }
        virtual public Status Status { get; set; }

        virtual public ICollection<MemberPerson> MemberPeople { get; set; }
    }

    
}
