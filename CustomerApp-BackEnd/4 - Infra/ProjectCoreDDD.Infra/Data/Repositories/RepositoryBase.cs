using Microsoft.EntityFrameworkCore;
using ProjectCoreDDD.Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCoreDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;
        public readonly DbSet<TEntity> DbSet;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
            DbSet = sqlContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await DbSet.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }     

        public void Remove(TEntity entity)
        {
            try
            {
                DbSet.Remove(entity);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                sqlContext.Entry(entity).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}