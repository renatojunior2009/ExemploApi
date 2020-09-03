using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories.Base
{
    public interface IRepositoryBaseAsync<T> : IDisposable where T: class, IEntityBase
    {
        Task<T> SaveAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<bool> DeleteAsync(object id);
        Task<int> UpdateAsync(T entity);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();        
    }
}
