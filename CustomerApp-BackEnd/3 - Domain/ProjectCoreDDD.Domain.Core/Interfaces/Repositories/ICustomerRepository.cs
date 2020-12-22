using ProjectCoreDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<List<Customer>> GetAllIncludeAsync();

        Task<List<Customer>> FilterAllIncludeAsync(Customer customer, DateTime? dateStart = null, DateTime? dateEnd = null);

        Task<List<City>> GetAllCities();
        Task<List<Classification>> GetAllClassifications();
        Task<List<Gender>> GetAllGenders();
        Task<List<Region>> GetAllRegions();
    }
}