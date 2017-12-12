using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickC.Services.DTO
{
    public class PaymentHistory
    {
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public PaymentHistory paymenthistory { get; set; }
    }
    public class PaymentSearch
    {
        public DateTime Datefrom { get; set; }
        public DateTime Dateto { get; set; }
    }
}
