using System;
using System.Collections.Generic;
using System.Linq;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Domain.Tests.Customers
{
    public class CustomerTestsService
    {
        public CustomerTestsService()
        {
        }

        public List<Customer> FilterAllInclude(Customer customer, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            var customers = GetCustomers();

            if (!string.IsNullOrEmpty(customer.Name))
                customers = customers.Where(x => x.Name.Contains(customer.Name)).ToList();

            if (customer.GenderId > 0)
                customers = customers.Where(x => x.GenderId == customer.GenderId).ToList();

            if (customer.CityId > 0)
                customers = customers.Where(x => x.CityId == customer.CityId).ToList();

            if (customer.RegionId > 0)
                customers = customers.Where(x => x.RegionId == customer.RegionId).ToList();

            if (dateStart != null && dateEnd != null)
                customers = customers.Where(x => x.LastPurchase >= dateStart && x.LastPurchase <= dateEnd).ToList();

            if (customer.ClassificationId > 0)
                customers = customers.Where(x => x.ClassificationId == customer.ClassificationId).ToList();

            // Seller
            if (customer.UserId > 0)
                customers = customers.Where(x => x.UserId == customer.UserId).ToList();

            return customers;
        }

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "Maurício", Phone = "(11) 95429999", GenderId = 1, CityId = 1, RegionId = 1, LastPurchase = new DateTime(2016, 9, 10), ClassificationId = 1, UserId = 3 });
            customers.Add(new Customer { Id = 2, Name = "Carla", Phone = "(53) 94569999", GenderId = 2, CityId = 1, RegionId = 1, LastPurchase = new DateTime(2015, 10, 10), ClassificationId = 1, UserId = 2 });
            customers.Add(new Customer { Id = 3, Name = "Maria", Phone = "(64) 94518888", GenderId = 2, CityId = 1, RegionId = 1, LastPurchase = new DateTime(2013, 10, 12), ClassificationId = 3, UserId = 2 });
            customers.Add(new Customer { Id = 4, Name = "Douglas", Phone = "(51) 12455555", GenderId = 1, CityId = 1, RegionId = 1, LastPurchase = new DateTime(2016, 5, 5), ClassificationId = 2, UserId = 2 });
            customers.Add(new Customer { Id = 5, Name = "Marta", Phone = "(51) 45788888", GenderId = 2, CityId = 1, RegionId = 1, LastPurchase = new DateTime(2016, 8, 8), ClassificationId = 2, UserId = 3 });

            return customers;
        }

        public Customer GetCustomerFilterForSeller1()
        {
            return new Customer()
            {
                // 2 - Seller1
                UserId = 2,
                User = new UserSys()
                {
                    // 2 - Seller1
                    Id = 2,
                    Login = "Seller1",
                    Email = "seller1@sellseverything.com",
                    Password = "16d15a9638baa256cfbe2b478def5eda",
                    UserRoleId = 2,
                }
            };
        }

        public Customer GetCustomerFilterForAdmin()
        {
            return new Customer()
            {
                User = new UserSys()
                {
                    // 2 - Seller1
                    Id = 1,
                    Login = "Administrator",
                    Email = "admin@sellseverything.com",
                    Password = "5533d6d8c8c2756a703a1dfa04b0f691",
                    UserRoleId = 1,
                }
            };
        }

        private DateTime dateRandom(int year)
        {
            var gen = new Random();
            DateTime start = new DateTime(year, 1, 1);
            DateTime end = new DateTime(year, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }

        /*
         * [0] : DateStart
         * [1] : DateEnd
         */
        public DateTime[] GetDateInterval(int yearStart, int yearEnd)
        {
            var date1 = dateRandom(yearStart);
            var date2 = dateRandom(yearEnd);

            return new[]
            {
                date1,
                date2
            };
        }
    }
}
