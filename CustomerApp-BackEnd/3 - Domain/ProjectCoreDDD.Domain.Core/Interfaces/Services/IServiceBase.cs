using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);
    }
}