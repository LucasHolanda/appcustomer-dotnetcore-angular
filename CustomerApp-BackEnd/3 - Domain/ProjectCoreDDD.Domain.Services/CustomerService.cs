using ProjectCoreDDD.Domain.Core.Interfaces.Repositories;
using ProjectCoreDDD.Domain.Core.Interfaces.Services;
using ProjectCoreDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository clienteRepository)
            : base(clienteRepository)
        {
            this.customerRepository = clienteRepository;
        }

        public async Task<List<Customer>> GetAllIncludeAsync()
        {
            return await customerRepository.GetAllIncludeAsync();
        }

        public async Task<List<Customer>> FilterAllIncludeAsync(Customer customer, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            return await customerRepository.FilterAllIncludeAsync(customer, dateStart, dateEnd);
        }

        public async Task<List<City>> GetAllCities()
        {
            return await customerRepository.GetAllCities();
        }

        public async Task<List<Classification>> GetAllClassifications()
        {
            return await customerRepository.GetAllClassifications();
        }

        public async Task<List<Gender>> GetAllGenders()
        {
            return await customerRepository.GetAllGenders();
        }

        public async Task<List<Region>> GetAllRegions()
        {
            return await customerRepository.GetAllRegions();
        }
    }
}