using ProjectCoreDDD.Application.Dtos;
using ProjectCoreDDD.Application.ResponseEvent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Application.Interfaces
{
    public interface IUserSysAppService
    {
        Task<ResponseResult> Add(UserSysDto userSysDto);

        Task<ResponseResult> Update(UserSysDto userSysDto);

        Task<ResponseResult> Remove(int id);

        Task<List<UserSysDto>> GetAllAsync();

        Task<UserSysDto> GetByIdAsync(int id);

        Task<ResponseResult> Login(UserSysDto userSysDto);
    }
}