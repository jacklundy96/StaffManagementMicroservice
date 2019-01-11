using StaffManagementMicroservice.Services;
using System;
using System.Net.Http;
using Xunit;

namespace StaffmanagementMicroserviceTest
{
    public class StaffServiceTest
    {
        private readonly StaffService _ss;

        public StaffServiceTest()
        {
            _ss = new StaffService(new HttpClient());
        }

        [Fact]
        public async void GetCustomerDetailsAsync_LimitTest()
        {
            //Arrange 
            int index = 0;
            //Act
            var result = await _ss.GetCustomerDetailsAsync(index);
            //Assert 
            Assert.Null(result);
        }

        [Fact]
        public async void GetCustomerDetailsAsync_InvalidCall()
        {
            //Arrange 
            int index = 1;
            //Act
            var result = await _ss.GetCustomerDetailsAsync(index);
            //Assert 
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetCustomerDetailsAsync_OutOfBoundsIndex()
        {
            //Arrange 
            int index = -1;
            //Act
            var result = await _ss.GetCustomerDetailsAsync(index);
            //Assert 
            Assert.Null(result);
        }
    }
}
