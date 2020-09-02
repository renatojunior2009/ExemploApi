using Domain.Entities.Base;
using Infrastructure.Interfaces.Repositories.Base;

namespace Infrastructure.Interfaces.Repositories.Domain
{
    public interface IDomainRepository<T> : IRepositoryBaseAsync<T> where T: class, IEntityBase
    {

    }
}
