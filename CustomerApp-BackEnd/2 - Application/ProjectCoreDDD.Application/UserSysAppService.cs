using AutoMapper;
using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.Interfaces;
using ProjectCoreDDD.Application.ResponseEvent;
using ProjectCoreDDD.Domain;
using ProjectCoreDDD.Domain.Core.Interfaces.Services;
using ProjectCoreDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Application
{
    public class UserSysAppService : IUserSysAppService
    {
        private const string nameEntity = "UserSys";
        private readonly IUserSysService userSysService;
        private readonly IMapper mapper;

        public UserSysAppService(IUserSysService userSysService, IMapper mapper)
        {
            this.userSysService = userSysService;
            this.mapper = mapper;
        }

        public async Task<ResponseResult> Add(UserSysDto userSysDto)
        {
            var userSys = mapper.Map<UserSys>(userSysDto);
            userSysService.Add(userSys);

            var response = new BaseResponse(userSys, $"{nameEntity} successfully registered!");

            return await response.Result;
        }

        public async Task<List<UserSysDto>> GetAllAsync()
        {
            var userSysDto = await userSysService.GetAllAsync();
            var userSysDtoDto = mapper.Map<List<UserSysDto>>(userSysDto);
            RemovePass(userSysDtoDto);

            return userSysDtoDto;
        }

        public async Task<UserSysDto> GetByIdAsync(int id)
        {
            var userSys = await userSysService.GetByIdAsync(id);
            var userSysDto = mapper.Map<UserSysDto>(userSys);

            return userSysDto;
        }

        public async Task<ResponseResult> Update(UserSysDto userSysDto)
        {
            var userSys = mapper.Map<UserSys>(userSysDto);
            userSysService.Update(userSys);

            var response = new BaseResponse(userSys, $"{nameEntity} successfully updated!");

            return await response.Result;
        }

        public async Task<ResponseResult> Remove(int id)
        {
            var produto = await userSysService.GetByIdAsync(id);
            userSysService.Remove(produto);

            var response = new BaseResponse($"{nameEntity} successfully deleted!");

            return await response.Result;
        }

        public async Task<ResponseResult> Login(UserSysDto userSysDto)
        {
            var userLogin = new UserSys { Login = userSysDto.Login, Password = CryptMD5.Generate(userSysDto.Password) };
            var userSys = await userSysService.Login(userLogin);
            if (userSys != null && userSys.Id > 0)
            {
                userSysDto = mapper.Map<UserSysDto>(userSys);
                userSysDto.Password = "";
                var response = new BaseResponse(userSysDto, "Authentication successful!");

                return await response.Result;
            }

            return await new BaseResponse(userSysDto.Login, false, "The email and/or password entered is invalid. Please try again.").Result;
        }

        private void RemovePass(List<UserSysDto> userSysDto)
        {
            userSysDto.ForEach(x => x.Password = "");
        }
    }
}