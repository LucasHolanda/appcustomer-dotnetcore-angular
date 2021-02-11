using System;
using System.Collections.Generic;
using System.Linq;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Domain.Tests.Session
{
    public class LoginTestsService
    {
        public LoginTestsService()
        {
        }

        public UserSys Login(string login, string password)
        {
            var user = GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);
            return user;
        }

        public List<UserSys> GetUsers()
        {
            var users = new List<UserSys>();
            users.Add(new UserSys { Id = 1, Login = "Administrator", Email = "admin@sellseverything.com", Password = "0192023a7bbd73250516f069df18b500" /* admin123 */, UserRoleId = 1 });
            users.Add(new UserSys { Id = 2, Login = "Seller1", Email = "seller1@sellseverything.com", Password = "1e4970ada8c054474cda889490de3421" /* seller123 */, UserRoleId = 2 });
            users.Add(new UserSys { Id = 3, Login = "Seller2", Email = "seller2@sellseverything.com", Password = "c6e36755ccaf770bdfe44928358055c2" /* seller2123 */, UserRoleId = 2 });

            return users;
        }

    }
}
