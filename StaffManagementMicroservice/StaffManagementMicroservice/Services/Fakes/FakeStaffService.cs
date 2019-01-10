using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffManagementMicroservice.DTOS;

namespace StaffManagementMicroservice.Services
{
    public class FakeStaffService : IStaffService
    {
        public List<StaffPermissions> StaffPermissions { get; set; }

        public FakeStaffService()
        {
            StaffPermissions = new List<StaffPermissions>()
            {
                new StaffPermissions()
                {
                    StaffID = 1,
                    EmployeeFullName = "Jack Lundy",
                    Permissions = "View customer Information"
                },
                new StaffPermissions()
                {
                    StaffID = 1,
                    EmployeeFullName = "Jack Lundy",
                    Permissions = "Toggle customer purchasing"
                },
               new StaffPermissions()
                {
                     StaffID = 2,
                    EmployeeFullName = "John Smith",
                    Permissions = "View customer Information"
                },
                new StaffPermissions()
                {
                    StaffID = 3,
                    EmployeeFullName = "Gavin Griff",
                    Permissions = "Toggle customer purchasing"
                },
                new StaffPermissions()
                {
                    StaffID = 4,
                    EmployeeFullName = "Sarah Jackson",
                    Permissions = "Create a sale window"
                },
                new StaffPermissions()
                {
                    StaffID = 5,
                    EmployeeFullName = "Melanie Andrews",
                    Permissions = "View stock"
                }
            };
        }

        public  async Task<StaffPermissions> GetCustomerDetailsAsync(int StaffID)
        {
            return  StaffPermissions.FirstOrDefault(c => c.StaffID == StaffID);
        }
    }
}
