using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master.Contract;

namespace Master.Contract
{
   public class CustomersDetails
    {
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public int TotalBookings { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
