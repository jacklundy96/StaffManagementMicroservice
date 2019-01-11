using StaffManagementMicroservice.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using StaffManagementMicroservice.DB;
using StaffManagementMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace StaffmanagementMicroserviceTest
{
    public class DBServiceTests
    {
        private static DbContextOptions<StaffPermContext> options;

        public DBServiceTests()
        {
            options = new DbContextOptionsBuilder<StaffPermContext>()
                .UseInMemoryDatabase(databaseName: "In memory Test database")
                .Options;
        }

        [Fact]
        public void GetStaffAllfPermissions_ValidCall()
        {
            using (var context = new StaffPermContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);
                _dbs.SaveStaff(new StaffPermissions()
                {
                    EmployeeFullName = "Mark Corrigan",
                    Permissions = "Can View customer details",
                    StaffID = 1
                });
                //Act
                var permissions = _dbs.GetStaffAllfPermissions(1);
                //Assert 
                Assert.NotNull(permissions);
            }
        }

        [Fact]
        public void GetStaffAllfPermissions_OutOfBoundsIndex()
        {
            using (var context = new StaffPermContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);

                //Act
                var permissions = _dbs.GetStaffAllfPermissions(-1);
                //Assert 
                Assert.Empty(permissions);
            }
        }

        [Fact]
        public void GetStaffAllfPermissions_LimitTest()
        {
            using (var context = new StaffPermContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);

                //Act
                var permissions = _dbs.GetStaffAllfPermissions(0);
                //Assert 
                Assert.Empty(permissions);
            }
        }

    }
}
