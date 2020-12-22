using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerAppService appService;

        public CustomerController(ICustomerAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CustomerDto>> Get() => await appService.GetAllAsync();

        [HttpGet]
        [Route("include-all")]
        [Authorize]
        public async Task<IEnumerable<CustomerDto>> GetAllInclude() => await appService.GetAllIncludeAsync();

        [HttpGet]
        [Route("filter-all")]
        [Authorize]
        public async Task<IEnumerable<CustomerDto>> FilterAllIncludeAsync([FromQuery]FilterCustomerDto filterCustomerDto) => await appService.FilterAllIncludeAsync(filterCustomerDto);

        [HttpGet("{id}")]
        [Authorize]
        public async Task<CustomerDto> Get(int id) => await appService.GetByIdAsync(id);

        [HttpGet]
        [Route("common-all")]
        [Authorize]
        public async Task<IActionResult> GetCommonAll()
        {
            try
            {
                var cities = await appService.GetAllCities();
                var classifications = await appService.GetAllClassifications();
                var genders = await appService.GetAllGenders();
                var regions = await appService.GetAllRegions();

                var optionsList = new
                {
                    cities,
                    classifications,
                    genders,
                    regions
                };

                return CustomResponse(optionsList, true, "options loaded successfully!");
            }
            catch (Exception ex)
            {
                return CustomResponse(ex, false, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post([FromBody] CustomerDto clienteDTO) => Response(await appService.Add(clienteDTO));

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put([FromBody] CustomerDto clienteDTO) => Response(await appService.Update(clienteDTO));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id) => Response(await appService.Remove(id));
    }
}
