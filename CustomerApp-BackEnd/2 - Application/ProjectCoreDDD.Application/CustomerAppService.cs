using AutoMapper;
using Newtonsoft.Json.Linq;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.Interfaces;
using ProjectCoreDDD.Application.ResponseEvent;
using ProjectCoreDDD.Domain.Core.Interfaces.Services;
using ProjectCoreDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Application
{
    public class CustomerAppService : ICustomerAppService
    {
        private const string nameEntity = "Customer";
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerAppService(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await customerService.GetAllAsync();
            var customersDto = mapper.Map<List<CustomerDto>>(customers);

            return customersDto;
        }

        public async Task<List<CustomerDto>> GetAllIncludeAsync()
        {
            var customers = await customerService.GetAllIncludeAsync();
            var customersDto = mapper.Map<List<CustomerDto>>(customers);
            return customersDto;
        }

        public async Task<List<CustomerDto>> FilterAllIncludeAsync(FilterCustomerDto filterCustomerDto)
        {
            var custDto = mapper.Map<CustomerDto>(filterCustomerDto);
            var customer = mapper.Map<Customer>(custDto);
            var customers = await customerService.FilterAllIncludeAsync(customer, filterCustomerDto.DateStart, filterCustomerDto.DateEnd);
            var customersDto = mapper.Map<List<CustomerDto>>(customers);
            return customersDto;
        }


        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await customerService.GetByIdAsync(id);
            var customerDto = mapper.Map<CustomerDto>(customer);

            return customerDto;
        }

        public async Task<ResponseResult> Add(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            customerService.Add(customer);
            var response = new BaseResponse(customer, $"{nameEntity} successfully registered!");

            return await response.Result;
        }

        public async Task<ResponseResult> Update(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            customerService.Update(customer);

            var response = new BaseResponse(customer, $"{nameEntity} successfully updated!");

            return await response.Result;
        }

        public async Task<ResponseResult> Remove(int id)
        {
            var customer = await customerService.GetByIdAsync(id);
            customerService.Remove(customer);

            var response = new BaseResponse($"{nameEntity} successfully deleted!");

            return await response.Result;
        }

        public async Task<List<CityDto>> GetAllCities()
        {
            var cities = await customerService.GetAllCities();
            var citiesDto = mapper.Map<List<CityDto>>(cities);

            return citiesDto;
        }

        public async Task<List<ClassificationDto>> GetAllClassifications()
        {
            var classifications = await customerService.GetAllClassifications();
            var classificationsDto = mapper.Map<List<ClassificationDto>>(classifications);

            return classificationsDto;
        }

        public async Task<List<GenderDto>> GetAllGenders()
        {
            var genders = await customerService.GetAllGenders();
            var gendersDto = mapper.Map<List<GenderDto>>(genders);

            return gendersDto;
        }

        public async Task<List<RegionDto>> GetAllRegions()
        {
            var regions = await customerService.GetAllRegions();
            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            return regionsDto;
        }
    }
}
