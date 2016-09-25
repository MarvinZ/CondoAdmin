using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class AmenityReservation : Audit
    {
        virtual public int Id { get; set; }

        virtual public int AmenityId { get; set; }
        virtual public Amenity Amenity { get; set; }

        virtual public int MemberId { get; set; }
//        virtual public Member Member { get; set; }


        virtual public int PersonId { get; set; }
        virtual public Person Person { get; set; }

        virtual public int AmenityReservationStatusId { get; set; }
        virtual public AmenityReservationStatus AmenityReservationStatus { get; set; }

        virtual public DateTime StartTime { get; set; }
        virtual public DateTime EndDatetime { get; set; }
        virtual public string Notes { get; set; }
    }
}
