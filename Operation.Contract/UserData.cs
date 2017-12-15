using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation.Contract
{
    public class UserData
    {
        public DateTime dateFrom { get; set; }
        public DateTime dateto { get; set; }
        public List<UserBookingList> userBookingList { get; set; }
        public List<CustomerStatus> customerStatusList { get; set; }
    }
    public class UserBookingList
    {
        public string MonthView { get; set; }
        public Int16 totaltrips { get; set; }
    }
    

}
