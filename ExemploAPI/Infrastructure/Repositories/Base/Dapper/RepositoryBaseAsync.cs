using Dapper;
using Domain.Entities.Base;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base.Dapper
{
    public abstract class RepositoryBaseAsync<T>: IRepositoryBaseAsync<T> where T: class, IEntityBase
    {
        #region Fields
        protected readonly IDbConnection _dbConnection;
        protected readonly IDbTransaction _dbTransaction;
        #endregion

        #region Properties 
        protected abstract string SqlSave { get; }
        protected abstract string SqlUpdate { get; }
        protected abstract string SqlDelete { get; }
        protected abstract string SqlGetById { get; }
        protected abstract string SqlGetAll { get; }

        #endregion

        #region Constructor
        protected RepositoryBaseAsync(IDatabaseFactory databaseFactory)
        {
            _dbConnection = databaseFactory.DBConnection;
        }

        protected RepositoryBaseAsync(IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            _dbConnection = dbConnection;

            if (_dbConnection.State != ConnectionState.Open) 
                _dbConnection.Open();

            _dbTransaction = dbTransaction;            
        }
        #endregion

        #region Public Methods 
        public async Task<T> SaveAsync(T entity)
        {
            T obj = await _dbConnection.QuerySingleAsync<T>(SqlSave, entity, transaction: _dbTransaction);
            return obj;
        }


        public async Task<bool> DeleteAsync(object id)
        {
            var obj = await GetByIdAsync(id);

            if (obj == null) 
                return false;

            return await DeleteAsync(obj) > 0;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await _dbConnection.ExecuteAsync(SqlDelete, entity, transaction: _dbTransaction);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await _dbConnection.ExecuteAsync(SqlUpdate, entity, transaction: _dbTransaction);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var obj = await _dbConnection.QueryAsync<T>(SqlGetById, new { Id = id }, transaction: _dbTransaction);
            return obj.FirstOrDefault();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbConnection.QueryAsync<T>(SqlGetAll, transaction: _dbTransaction);
        }

        public void Dispose()
        {
            _dbConnection.Close();
            _dbConnection.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion

    }
}
