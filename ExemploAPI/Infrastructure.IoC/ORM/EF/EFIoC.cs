using Infrastructure.DBConfiguration.ContextEFCore;
using Infrastructure.Interfaces.Repositories.Base;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Base.EF;
using Infrastructure.Repositories.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.ORM.EF
{
    public class EFIoC : ORMTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration configurationSettings = ResolverConfiguration.GetConfigurationSettings(configuration);
            string connectionString = configurationSettings.GetConnectionString("DefaultConnection");

            #region Context EF
            services.AddScoped<DbContext, Context>();
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            #endregion

            #region Register Repositories 

            services.AddScoped(typeof(IRepositoryBaseAsync<>), typeof(RepositoryBaseAsync<>));
            services.AddScoped<IClientRepository, ClientRepository>(); 
            #endregion

            return services;
        }
    }
}
