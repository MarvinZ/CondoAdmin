using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Person: Audit
    {
        virtual public int Id { get; set; }
        virtual public string FirstName { get; set; }
        virtual public string SecondName { get; set; }
        virtual public string LastName { get; set; }
        virtual public string LastName2 { get; set; }
        virtual public DateTime DateOfBirth { get; set; }
        virtual public string Phone { get; set; }
        virtual public string Address { get; set; }
        virtual public string Email { get; set; }
        virtual public ICollection<MemberPerson> Memberships { get; set; }


    }
}
