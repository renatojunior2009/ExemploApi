using Dapper;
using Domain;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Base.Dapper;
using System.Collections;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Domain.Dapper
{
    public class ClientRepository : DomainRepository<Client>, IClientRepository
    {      
        #region Properties
        protected override string SqlSave => $"INSERT INTO [{nameof(Client)}] VALUES (@{nameof(Client.Codigo)}, @{nameof(Client.Nome)}, @{nameof(Client.Sobrenome)}, @{nameof(Client.Especial)}, @{nameof(Client.LimiteCredito)})";
        protected override string SqlUpdate => $"UPDATE [{nameof(Client)}] SET {nameof(Client.Nome)} = @{nameof(Client.Nome)} WHERE {nameof(Client.Id)} = @{nameof(Client.Id)}";
        protected override string SqlDelete => $"DELETE FROM [{nameof(Client)}] WHERE {nameof(Client.Id)} = @{nameof(Client.Id)}";
        protected override string SqlGetById => $"SELECT * FROM [{nameof(Client)}] WHERE {nameof(Client.Id)} = @{nameof(Client.Id)}";
        protected override string SqlGetAll => $"SELECT * FROM [{nameof(Client)}]";
        #endregion

        #region Privates Properties
        private string SqlSpecialCustomers => $"SELECT c.* FROM [{nameof(Client)}] c WHERE c.{nameof(Client.Especial)} = 1"; 
        #endregion

        #region Constructors
        public ClientRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
        public ClientRepository(IDbConnection dbConnection, IDbTransaction dbTransaction) : base(dbConnection, dbTransaction) { }
        #endregion

        #region Methods
        public async Task<IEnumerable> GetSpecialsCustomers()
        {
            return await _dbConnection.QueryAsync<Client>(SqlSpecialCustomers, transaction: _dbTransaction);
        } 
        #endregion

    }
}
