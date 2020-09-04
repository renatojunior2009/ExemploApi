using Infrastructure.DBConfiguration.Dapper;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Domain.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.IoC.ORM.Dapper
{
    public class IoC : ORMTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration configurationSettings = ResolverConfiguration.GetConfigurationSettings(configuration);

            #region Register Configuration
            services.Configure<DataSettings>(configurationSettings);
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();

            #endregion

            #region Register Repositories 
            services.AddScoped<IClientRepository, ClientRepository>();
            #endregion

            return services;
        }
    }
}
