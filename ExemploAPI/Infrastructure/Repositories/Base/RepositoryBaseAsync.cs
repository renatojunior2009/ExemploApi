using Domain.Entities.Base;
using Infrastructure.Interfaces.Repositories.Base;
using Infrastructure.Interfaces.Repositories.SpecificMethodsEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class RepositoryBaseAsync<T> : SpecificMethods<T>, IRepositoryBaseAsync<T> where T : class, IEntityBase
    {
        #region Fields
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet; 
        #endregion

        #region Constructor
        public RepositoryBaseAsync(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        #endregion

        #region Public Methods
        public async Task<T> SaveAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(object id)
        {
            T entity = await GetByIdAsync(id);
            if (entity == null) 
                return false;

            return await DeleteAsync(entity) > 0 ? true : false;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await SaveChangesAsync();
        }
       
        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }
  
        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
        
        #region Protected Methods

        protected override IQueryable<T> GenerateQuery(Expression<Func<T, bool>> conditions = null, Func<IQueryable<T>, IOrderedQueryable<T>> hasOrdination = null, params string[] parameters)
        {
            IQueryable<T> query = _dbSet;
            query = GenerateQueryConditions(query, conditions);
            query = GenereteIncludeParameters(query, parameters);

            if (hasOrdination != null)
                return hasOrdination(query);

            return query;
        }
     
       
        #endregion

        #region Private Methods
        private async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> GenerateQueryConditions(IQueryable<T> query, Expression<Func<T, bool>> conditions)
        {
            if (conditions != null)
                return query.Where(conditions);

            return query;
        }

        private IQueryable<T> GenereteIncludeParameters(IQueryable<T> query, string[] parameters)
        {
            foreach (var param in parameters)
            {
                query = query.Include(param);
            }

            return query;
        }

        #endregion
    }
}
