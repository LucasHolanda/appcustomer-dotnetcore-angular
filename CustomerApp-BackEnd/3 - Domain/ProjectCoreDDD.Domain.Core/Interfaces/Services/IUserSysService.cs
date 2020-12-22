using ProjectCoreDDD.Domain.Entities;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Domain.Core.Interfaces.Services
{
    public interface IUserSysService : IServiceBase<UserSys>
    {
        Task<UserSys> Login(UserSys userSys);
    }
}