﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class AmenityReservationStatus : Audit
    {
        virtual public int Id { get; set; }
        virtual public string  Name { get; set; }
    }
}
