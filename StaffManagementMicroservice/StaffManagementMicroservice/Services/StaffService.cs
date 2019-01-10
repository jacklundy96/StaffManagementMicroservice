using Newtonsoft.Json.Linq;
using StaffManagementMicroservice.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StaffManagementMicroservice.Services
{
    public interface IStaffService
    {
        Task<StaffPermissions> GetCustomerDetailsAsync(int StaffID);
    }

    public class StaffService : IStaffService
    {
        private readonly HttpClient _client;

        public StaffService(HttpClient client)
        {
            _client = client;
        }

        public async Task<StaffPermissions> GetCustomerDetailsAsync(int StaffID)
        {
            HttpResponseMessage response = await _client.GetAsync("http://www.ThamcoCustomers.com/StaffDetails/" + StaffID);
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffPermissions staff = ParseJsonIntoStaffAsync(responseBody);

            return staff;
        }

        private StaffPermissions ParseJsonIntoStaffAsync(string responseBody)
        {
            StaffPermissions staff = new StaffPermissions()
            {
                StaffID = (int)JObject.Parse(responseBody)["StaffID"],
                EmployeeFullName = JObject.Parse(responseBody)["EmployeeFullName"].ToString(),
                Permissions = JObject.Parse(responseBody)["Permissions"].ToString()
            };
            return staff;
        }
    }
}
