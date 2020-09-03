using Application.Interfaces.Base;
using Domain.Entities.Base;
using Infrastructure.Interfaces.Repositories.Base;
using System.Threading.Tasks;

namespace Application.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : class, IEntityBase
    {
        #region Fields
        protected readonly IRepositoryBaseAsync<T> _repository;
        #endregion

        #region Constructor
        public ServiceBase(IRepositoryBaseAsync<T> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods
        public async Task<T> SaveAsync(T entity)
        {
            return await _repository.SaveAsync(entity);
        } 

        #endregion
    }
}
