
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PickC.Services.DTO;


using PickC.Services;

namespace PickC.Internal2.Controllers
{
    [WebAuthFilter]
    [PickCEx]
    public class CustomersController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            //var customerlist = new List<CustomerDTO>();
            var customerlist = await new CustomerService(AUTHTOKEN, p_mobileNo).GetCustomerListAsync();

            return View(customerlist);
        }
    }
}