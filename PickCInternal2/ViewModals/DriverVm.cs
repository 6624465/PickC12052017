using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Master.Contract;
using PickC.Services.DTO;

namespace PickC.Internal2.ViewModals
{
    public class DriverVm
    {
        public Driver driver { get; set; }
        public DriverLookupDTO driverLookupDTO { get; set; }
        public DeviceDetails devicedetails { get; set; }
    }
    public class DeviceDetails
    {
        public string Mobilemake { get; set; }
        public string Modelno { get; set; }
        public DateTime Dateofissue { get; set; }
        public DateTime Dateofreturn { get; set; }
    }
}