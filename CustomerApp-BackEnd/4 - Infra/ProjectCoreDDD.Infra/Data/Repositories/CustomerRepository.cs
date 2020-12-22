using Microsoft.EntityFrameworkCore;
using ProjectCoreDDD.Domain.Core.Interfaces.Repositories;
using ProjectCoreDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Infra.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly SqlContext sqlContext;

        public CustomerRepository(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;

        }

        public async Task<List<Customer>> GetAllIncludeAsync()
        {
            try
            {

                var customers = await DbSet.Include(x => x.Classification)
                                  .Include(x => x.City)
                                  .Include(x => x.Gender)
                                  .Include(x => x.Region)
                                  .Include(x => x.User)
                                  .ToListAsync();

                RemovePass(customers);
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Customer>> FilterAllIncludeAsync(Customer customer, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            try
            {
                var query = DbSet.AsQueryable();
                if (customer != null)
                {

                    if (!string.IsNullOrEmpty(customer.Name))
                        query = query.Where(x => x.Name.Contains(customer.Name));

                    if (customer.GenderId > 0)
                        query = query.Where(x => x.GenderId == customer.GenderId);

                    if (customer.CityId > 0)
                        query = query.Where(x => x.CityId == customer.CityId);

                    if (customer.RegionId > 0)
                        query = query.Where(x => x.RegionId == customer.RegionId);

                    if (dateStart != null && dateEnd != null)
                        query = query.Where(x => x.LastPurchase >= dateStart && x.LastPurchase <= dateEnd);

                    if (customer.ClassificationId > 0)
                        query = query.Where(x => x.ClassificationId == customer.ClassificationId);

                    // Seller
                    if (customer.UserId > 0)
                        query = query.Where(x => x.UserId == customer.UserId);
                }

                var customers = await query.Include(x => x.Classification)
                                  .Include(x => x.City)
                                  .Include(x => x.Gender)
                                  .Include(x => x.Region)
                                  .Include(x => x.User).ToListAsync();

                RemovePass(customers);
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<City>> GetAllCities()
        {
            try
            {
                return await sqlContext.Set<City>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Classification>> GetAllClassifications()
        {
            try
            {
                return await sqlContext.Set<Classification>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Gender>> GetAllGenders()
        {
            try
            {
                return await sqlContext.Set<Gender>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Region>> GetAllRegions()
        {
            try
            {
                return await sqlContext.Set<Region>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemovePass(List<Customer> customers)
        {
            customers.ForEach(x => x.User.Password = "");
        }
    }
}