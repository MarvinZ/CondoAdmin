using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class AeroOrder : Audit
    {
        virtual public int Id { get; set; }
        virtual public int AeroOrderStatusId { get; set; }
        virtual public AeroOrderStatus AeroOrderStatus { get; set; }
        virtual public int DeliveryStatusId { get; set; }
        virtual public DeliveryStatus DeliveryStatus { get; set; }
        virtual public int CourierId { get; set; }
        virtual public Courier Courier { get; set; }
        virtual public string CourierTrackingNumber { get; set; }
        virtual public string Name { get; set; }
        virtual public string Description { get; set; }
        virtual public decimal Value { get; set; }
        virtual public DateTime EnteredDateTime { get; set; }
        virtual public DateTime ExpectedUSDeliveryDateTimeStart { get; set; }
        virtual public DateTime ExpectedUSDeliveryDateTimeEnd { get; set; }
        virtual public DateTime ExpectedCRDeliveryDateTime { get; set; }
        virtual public DateTime DeliveryDateTime { get; set; }


        //virtual public double Double { get; set; }
        //virtual public decimal Decimal { get; set; }
        //virtual public ICollection<Status> Statuses { get; set; }
        //virtual public bool  Booly { get; set; }
        //virtual public string  Name { get; set; }
        //virtual public DateTime Datetime { get; set; }



    }
}
