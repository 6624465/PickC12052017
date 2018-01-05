﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Contract
{
   public class DriverRating :IContract
    {
        public string BookingNo { get; set; }
        public string DriverId { get; set; }
        public Int32 Rating { get; set; }
        public string Remarks { get; set; }
    }
}
