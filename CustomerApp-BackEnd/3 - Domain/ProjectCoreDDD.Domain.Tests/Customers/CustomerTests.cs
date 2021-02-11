using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace ProjectCoreDDD.Domain.Tests.Customers
{
    public class CustomerTests
    {
        public CustomerTestsService service { get; set; }

        public CustomerTests()
        {
            service = new CustomerTestsService();
        }

        [Fact]
        public void FilterAllInclude_With_SellerUser_ShouldBeValid()
        {
            var customerFilterSeller = service.GetCustomerFilterForSeller1();

            var customers = service.FilterAllInclude(customerFilterSeller, null,null);

            var result = customers.Any(x => x.UserId != customerFilterSeller.UserId);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("2013-01-01","2015-12-31")]
        public void FilterAllInclude_With_SellerUser_And_Dates_ShouldBeValid(string dateStartString, string dateEndString)
        {
            // userId: 2 | Seller1
            var customerFilterSeller = service.GetCustomerFilterForSeller1();
            var dateStart = DateTime.Parse(dateStartString);
            var dateEnd = DateTime.Parse(dateEndString);
            var customers = service.FilterAllInclude(customerFilterSeller, dateStart, dateEnd);

            var result = customers.Any(x => x.UserId == customerFilterSeller.User.Id && x.LastPurchase >= dateStart && x.LastPurchase <= dateEnd);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(3)] // userId: 3 | Seller2
        public void FilterAllInclude_With_SellerUser_ShouldBeInvalid(int userId)
        {
            // userId: 2 | Seller1
            var customerFilterSeller = service.GetCustomerFilterForSeller1();
            var customers = service.FilterAllInclude(customerFilterSeller, null, null);

            // userId: 3 | Seller2
            var result = customers.Any(x => x.UserId == userId);
            result.Should().BeFalse();
        }
    }
}
