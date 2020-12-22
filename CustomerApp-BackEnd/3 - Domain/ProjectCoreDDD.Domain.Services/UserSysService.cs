using ProjectCoreDDD.Domain.Core.Interfaces.Repositories;
using ProjectCoreDDD.Domain.Core.Interfaces.Services;
using ProjectCoreDDD.Domain.Entities;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Domain.Services
{
    public class UserSysService : ServiceBase<UserSys>, IUserSysService
    {
        private readonly IUserSysRepository userSysRepository;

        public UserSysService(IUserSysRepository userSysRepository)
            : base(userSysRepository)
        {
            this.userSysRepository = userSysRepository;
        }

        public async Task<UserSys> Login(UserSys userSys)
        {
            return await userSysRepository.Login(userSys);
        }
    }
}
