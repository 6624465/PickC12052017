using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PickC.Services;
using PickC.Internal2.ViewModals;
using PickC.Services.DTO;
using Operation.Contract;
using Operation.BusinessFactory;


namespace PickC.Internal2.Controllers
{
    [WebAuthFilter]
    [PickCEx]

    public class DashboardController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await GetTripMonitorData());
        }

        [HttpGet]
        public async Task<JsonResult> GetTripMonitorInfo()
        {
            return Json(await GetTripMonitorData(), JsonRequestBehavior.AllowGet);
        }

        public async Task<List<TripMonitorVm>> GetTripMonitorData()
        {
            var tripMonitorList = await new TripMonitorService(AUTHTOKEN, p_mobileNo)
                                            .TripMonitorListAsync();

            var tripMonitorData = new List<TripMonitorVm>();
            if (tripMonitorList != null)
            {
                for (var i = 0; i < tripMonitorList.Count; i++)
                {
                    var tripMonitor = new TripMonitorVm();
                    tripMonitor.address = new ViewModals.Address
                    {
                        address = "",
                        lat = tripMonitorList[i].Latitude,
                        lng = tripMonitorList[i].Longitude,
                    };
                    tripMonitor.title = tripMonitorList[i].DriverID + " - " + tripMonitorList[i].TripID;

                    tripMonitorData.Add(tripMonitor);
                }
            }


            return tripMonitorData;
        }

        public async Task<ActionResult> GetDriversList()
        {
            var status = "ALL";
            var driverList = await new DriverService(AUTHTOKEN, p_mobileNo).GetDriverBySearch(status);
            var tripMonitor = await GetTripMonitorData();

            var driverMonitorVm = new DriverMonitorVm()
            {
                driverList = driverList,
                tripMonitorVmList = tripMonitor
            };

            return View(driverMonitorVm);
            //return View();
        }

        [HttpPost]
        public async Task<ActionResult> CurrentBookings(BookingDTO search)
        {
            var currentbookings = await new SearchService(AUTHTOKEN, p_mobileNo).SearchCurrentBookingAsync(search);
            var bookingSearchVM = new BookingSearchDTO();
            bookingSearchVM.booking = currentbookings;
            return View("SearchBookingHistory", bookingSearchVM);
        }
        [HttpGet]
        public async Task<ActionResult> CurrentBookings()
        {
            var currentbookings = await new SearchService(AUTHTOKEN, p_mobileNo).BookingListAsync();
            var bookingSearchVM = new BookingSearchDTO();
            bookingSearchVM.booking = currentbookings;
            var tripMonitor = await GetTripMonitorData();
            ViewBag.trips = tripMonitor;
            return View(bookingSearchVM);
        }
        public async Task<JsonResult> GetCustomerBySearch(int? status)
        {
            var customerlist = await new SearchService(AUTHTOKEN, p_mobileNo).GetCustomerBySearch(status);
            return Json(customerlist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CurrentBookings(BookingSearchDTO booking)
        {
            var currentbooking = await new SearchService(AUTHTOKEN, p_mobileNo).SearchBookingByDateAsync(booking);
            var bookingSearchVM = new BookingSearchDTO();
            bookingSearchVM.booking = currentbooking;

            return View("CurrentBookings", bookingSearchVM);

        }
        [HttpGet]
        public async Task<ActionResult> BookingHistory()
        {
            var bookingHistory1 = await new SearchService(AUTHTOKEN, p_mobileNo).BookingListAsync();
            var bookingSearchVM = new BookingHistoryDTO();
            bookingSearchVM.booking = bookingHistory1;
            //bookingSearchVM.bookingHistory = bookingHistory;
            return View("BookingHistory", bookingSearchVM);
        }
        [HttpPost]
        public async Task<ActionResult> BookingsHistory(BookingHistoryDTO search)
        {
            var bookingHistory = await new SearchService(AUTHTOKEN, p_mobileNo).SearchBookingAsync(search.bookings);
            var bookingSearchVM = new BookingHistoryDTO();
            bookingSearchVM.booking = bookingHistory;
            return View("SearchBookingHistory", bookingSearchVM);
        }
        [HttpPost]
        public async Task<ActionResult> SearchBookingsHistory(BookingHistoryDTO search)
        {
            var bookingHistory = await new SearchService(AUTHTOKEN, p_mobileNo).SearchBookingAsync(search.bookings);
            var bookingSearchVM = new BookingHistoryDTO();
            bookingSearchVM.booking = bookingHistory;
            return View("SearchBookingHistory", bookingSearchVM);
        }
        [HttpGet]
        public async Task<ActionResult> UserApp()
        {
            ViewBag.totalBookings = await new UserService(AUTHTOKEN, p_mobileNo).GetBookingsCount();
            ViewBag.totalRegistered = await new UserService(AUTHTOKEN, p_mobileNo).GetRegisteredCount();
            //var CustomerList = await new UserService(AUTHTOKEN, p_mobileNo).GetRegisteredButNotBookedList();
            var userData = new UserData();
            userData.dateFrom = DateTime.Now;
            userData.dateto = DateTime.Now;
            return View("UserApp", userData);
        }
        [HttpGet]
        public  ActionResult RegisteredList()
        {
            var userData = new UserData();
            DateTime dateTime = DateTime.Now;
            userData.dateFrom = new DateTime(dateTime.Year, dateTime.Month, 1);
            userData.dateto = DateTime.Now;
            return View("RegisteredList", userData);
        }
        [HttpPost]
        public async Task<ActionResult> RegisteredList(UserData user)
        {
            var CustomerList = await new UserService(AUTHTOKEN, p_mobileNo).GetRegisteredButNotBookedList();
            var userData = new UserData();
            userData.customerStatusList = new List<CustomerStatus>();
            userData.customerStatusList = CustomerList;
            userData.dateFrom = DateTime.Now;
            userData.dateto = DateTime.Now;
            return View("RegisteredList", userData);
        }
        [HttpPost]
        public async Task<ActionResult> SearchTotalTrips(UserData userdata)

        {
            ViewBag.totalBookings = await new UserService(AUTHTOKEN, p_mobileNo).GetBookingsCount();
            ViewBag.totalRegistered = await new UserService(AUTHTOKEN, p_mobileNo).GetRegisteredCount();
            var UserList = await new UserService(AUTHTOKEN, p_mobileNo).searchBookingTripsAsync(userdata);
            //var CustomerList = await new UserService(AUTHTOKEN, p_mobileNo).GetRegisteredButNotBookedList();
            var userData = new UserData();
            userData.userBookingList = UserList;
           // userdata.customerStatusList = CustomerList;
            return View("UserApp", userData);
        }
        //public async Task<ActionResult> getRegisteredList()
        //{
        //    return View("UserRegister");
        //}
        [HttpGet]
        public ActionResult PaymentHistory()
        {
            return View("PaymentHistory");
        }
        [HttpGet]
        public ActionResult PendingAmount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PendingAmounts(PendingAmountDTO pendingAmountDTO)
        {
            return View();
        }
        public async Task<JsonResult> GetDriverBySearch(string status)
        {
            var driverList = await new DriverService(AUTHTOKEN, p_mobileNo).GetDriverBySearch(status);

            return Json(driverList, JsonRequestBehavior.AllowGet);
            //return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetDriverDetails(string id)
        {
            var driverlist = await new DriverService(AUTHTOKEN, p_mobileNo).DriverInfoAsync(id);
            return Json(driverlist, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> IsValidOperatorId(string operatorId)
        {
            string operatorDetails = await new DriverService(AUTHTOKEN, p_mobileNo).IsOperatorValid(operatorId);
            int i = Convert.ToInt32(operatorDetails);
            return Json(i, JsonRequestBehavior.AllowGet);
        }
    }
}