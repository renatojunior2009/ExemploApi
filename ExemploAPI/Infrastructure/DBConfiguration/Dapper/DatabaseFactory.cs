using Infrastructure.Interfaces.DBConfiguration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infrastructure.DBConfiguration.Dapper
{
    public class DatabaseFactory : IDatabaseFactory
    {
        #region Fields
        private IOptions<DataSettings> _dataSettings;
        #endregion

        #region Properties
        protected string ConnectionString => !string.IsNullOrEmpty(_dataSettings.Value.DefaultConnection) ?
                                            _dataSettings.Value.DefaultConnection : DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection");

        public IDbConnection DBConnection { get => new SqlConnection(ConnectionString); }

        #endregion

        #region Constructor
        public DatabaseFactory(IOptions<DataSettings> dataSettings)
        {
            _dataSettings = dataSettings;
        }
    } 
    #endregion
}
