using Newtonsoft.Json.Linq;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.ResponseEvent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<ResponseResult> Add(CustomerDto customerDto);

        Task<ResponseResult> Update(CustomerDto customerDto);

        Task<ResponseResult> Remove(int id);

        Task<List<CustomerDto>> GetAllAsync();

        Task<CustomerDto> GetByIdAsync(int id);

        Task<List<CustomerDto>> GetAllIncludeAsync();

        Task<List<CustomerDto>> FilterAllIncludeAsync(FilterCustomerDto filterCustomerDto);
        Task<List<CityDto>> GetAllCities();
        Task<List<ClassificationDto>> GetAllClassifications();
        Task<List<GenderDto>> GetAllGenders();
        Task<List<RegionDto>> GetAllRegions();
    }
}