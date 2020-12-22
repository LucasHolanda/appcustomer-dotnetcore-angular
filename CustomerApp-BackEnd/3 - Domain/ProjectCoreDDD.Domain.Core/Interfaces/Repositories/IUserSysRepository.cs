using ProjectCoreDDD.Domain.Entities;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Domain.Core.Interfaces.Repositories
{
    public interface IUserSysRepository : IRepositoryBase<UserSys>
    {
        Task<UserSys> Login(UserSys userSys);
    }
}