using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSysController : BaseController
    {
        private readonly IUserSysAppService appService;

        public UserSysController(IUserSysAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserSysDto>> Get() => await appService.GetAllAsync();

        [HttpGet("{id}")]
        [Authorize]
        public async Task<UserSysDto> Get(int id) => await appService.GetByIdAsync(id);

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post([FromBody] UserSysDto ProdutoDto) => Response(await appService.Add(ProdutoDto));

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Put([FromBody] UserSysDto ProdutoDto) => Response(await appService.Update(ProdutoDto));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id) => Response(await appService.Remove(id));
    }
}