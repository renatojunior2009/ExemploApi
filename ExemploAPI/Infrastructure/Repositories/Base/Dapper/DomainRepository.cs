using Domain.Entities.Base;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Data;

namespace Infrastructure.Repositories.Base.Dapper
{
    public abstract class DomainRepository<T>: RepositoryBaseAsync<T>, IDomainRepository<T> where T: class, IEntityBase
    {
        protected DomainRepository(IDatabaseFactory databaseFactory): base(databaseFactory) {}
        protected DomainRepository(IDbConnection dbConnection, IDbTransaction dbTransaction): base(dbConnection, dbTransaction) { }
    }
}
