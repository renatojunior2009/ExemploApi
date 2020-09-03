using Domain.Entities.Base;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Domain
{
    public class DomainRepository<T>: RepositoryBaseAsync<T>, IDomainRepository<T> where T: class, IEntityBase
    {
        #region Constructor
        public DomainRepository(DbContext dbContext) : base(dbContext) { } 
        #endregion
    }
}
