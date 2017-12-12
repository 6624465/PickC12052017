using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operation.Contract;
using RestSharp;

namespace PickC.Services
{
    public class UserService:Service
    {
        public UserService(string token ,string mobileNo):base(token,mobileNo)
        {

        }
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public async Task<List<UserBookingList>> searchBookingTripsAsync(UserData userdata)
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.POST;
            request.Resource = "operation/trip/totalTrips";
            request.AddJsonBody(userdata);

            return ServiceResponse(
                await client.ExecuteTaskAsync<List<UserBookingList>>(request));
        }
      public async Task<Int64> GetBookingsCount()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "operation/trip/BookingCount";
            return ServiceResponse(await client.ExecuteTaskAsync<Int64>(request));
        }
        public async Task<Int64> GetRegisteredCount()
        {
            IRestClient client = new RestClient(ApiBaseUrl);
            var request = p_request;
            request.Method = Method.GET;
            request.Resource = "operation/trip/RegisteredCount";
            return ServiceResponse(await client.ExecuteTaskAsync<Int64>(request));
        }
    }
}
