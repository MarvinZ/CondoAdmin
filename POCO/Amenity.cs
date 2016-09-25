using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Amenity : Audit
    {
        virtual public int Id { get; set; }
        virtual public int CondoId { get; set; }
        virtual public Condo Condo { get; set; }
        virtual public string  Name { get; set; }
        virtual public string Description { get; set; }

    }
}
