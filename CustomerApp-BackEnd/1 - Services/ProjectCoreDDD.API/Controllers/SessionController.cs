using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.Interfaces;
using ProjectCoreDDD.Infra.CrossCutting.Auth;
using System;
using System.Threading.Tasks;

namespace ProjectCoreDDD.API.Controllers
{
    [Route("Account")]
    [ApiController]
    public class SessionController : BaseController
    {
        private readonly IUserSysAppService appService;

        public SessionController(IUserSysAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] UserSysDto user)
        {
            try
            {
                // Recupera o usuário
                var responseResult = await appService.Login(user);

                if (responseResult.Success)
                {
                    user = (UserSysDto)responseResult.Data;
                    // Gera o Token
                    var token = TokenService.GenerateToken(user.Login, user.UserRole.Name);
                    responseResult.Data = new { user, token };
                }

                return Response(responseResult);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex, false, ex.Message);
            }
        }
    }
}