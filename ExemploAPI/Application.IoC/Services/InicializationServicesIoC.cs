using Application.Base;
using Application.Domain;
using Application.Interfaces.Base;
using Application.Interfaces.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC.Services
{

    public static class InicializationServicesIoC
    {
        public static void StartupsDependenciesServices(this IServiceCollection services)
        { 
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
