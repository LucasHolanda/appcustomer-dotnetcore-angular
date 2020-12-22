using Microsoft.EntityFrameworkCore;
using ProjectCoreDDD.Domain.Core.Interfaces.Repositories;
using ProjectCoreDDD.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Infra.Data.Repositories
{
    public class UserSysRepository : RepositoryBase<UserSys>, IUserSysRepository
    {
        private readonly SqlContext sqlContext;

        public UserSysRepository(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public async Task<UserSys> Login(UserSys userSys)
        {
            try
            {
                return await DbSet.Include(x => x.UserRole).FirstOrDefaultAsync(x => x.Login == userSys.Login && x.Password == userSys.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}