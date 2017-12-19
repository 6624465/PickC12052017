using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickC.Services.DTO
{
    public class PaymentHistory
    {
        //public DateTime? Datefrom { get; set; }
        //public DateTime? Dateto { get; set; }
        public Paymentsearch paymentsearch { get; set; }
        public List<DriverCommissionDetails> driverCommissiondetails { get; set; }
        public List<pickCCommissionDetails> pickCCommissiondetails { get; set; }
        public List<CustomerDetails> customerdetails { get; set; }
    }
    public class Paymentsearch
    {
        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
    }
    public class DriverCommissionDetails
    {
        public string DriverName { get; set; }
        public string VehicleNo { get; set; }
        public string TripId { get; set; }
        public decimal driverCommission { get; set; }

    }
    public class pickCCommissionDetails
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal GST { get; set; }
        public decimal PickcCommision { get; set; }

    }
    public class CustomerDetails
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
    }
   
}
