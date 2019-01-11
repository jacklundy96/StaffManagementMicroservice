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
    class DBServiceTests
    {
        private static DbContextOptions<StaffPermContext> options;

        public DBServiceTests()
        {
            options = new DbContextOptionsBuilder<StaffPermContext>()
                .UseInMemoryDatabase(databaseName: "In memory Test database")
                .Options;

        }

        public void GetStaffAllfPermissions_ValidCall(int staffID)
        {
            using (var context = new StaffPermContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);

                //Act
                var permissions = _dbs.GetStaffAllfPermissions(1);
                //Assert 
                Assert.NotNull(permissions);
            }
        }


        public void GetStaffAllfPermissions_OutOfBoundsIndex(int staffID)
        {
            using (var context = new StaffPermContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);

                //Act
                var permissions = _dbs.GetStaffAllfPermissions(-1);
                //Assert 
                Assert.NotNull(permissions);
            }
        }

        public void GetStaffAllfPermissions_LimitTest(int staffID)
        {
            using (var context = new StaffPermContext(options))
            {
                //Arrange
                var _dbs = new DBService(context);

                //Act
                var permissions = _dbs.GetStaffAllfPermissions(0);
                //Assert 
                Assert.NotNull(permissions);
            }
        }

    }
}
