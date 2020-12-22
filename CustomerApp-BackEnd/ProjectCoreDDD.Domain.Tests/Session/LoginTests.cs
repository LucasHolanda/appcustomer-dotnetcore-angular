using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace ProjectCoreDDD.Domain.Tests.Session
{
    public class LoginTests
    {
        public LoginTestsService service { get; set; }

        public LoginTests()
        {
            service = new LoginTestsService();
        }

        [Theory]
        [InlineData("Administrator", "admin12345")] // Password Incorret
        public void Login_As_Admin_ShouldBeInvalid(string login, string password)
        {
            var user = service.Login(login, CryptMD5.Generate(password));
            var result = user != null && user.Id > 0;
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("Administrator", "admin123")] // Password Correct
        public void Login_As_Admin_ShouldBeValid(string login, string password)
        {
            var user = service.Login(login, CryptMD5.Generate(password));
            var result = user != null && user.Id > 0;
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("Seller1", "seller112344455")] // Password Incorret
        public void Login_As_Seller_ShouldBeInvalid(string login, string password)
        {
            var user = service.Login(login, CryptMD5.Generate(password));
            var result = user != null && user.Id > 0;
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("Seller1", "seller123")] // Password Correct
        public void Login_As_Seller_ShouldBeValid(string login, string password)
        {
            var user = service.Login(login, CryptMD5.Generate(password));
            var result = user != null && user.Id > 0;
            result.Should().BeTrue();
        }
    }
}
