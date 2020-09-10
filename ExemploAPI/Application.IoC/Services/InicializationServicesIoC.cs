using Application.Base;
using Application.Domain;
using Application.MessageService;
using Application.Interfaces.Base;
using Application.Interfaces.Domain;
using Application.Interfaces.MessageService;
using Microsoft.Extensions.DependencyInjection;


namespace Application.IoC.Services
{

    public static class InicializationServicesIoC
    {
        public static void StartupsDependenciesServices(this IServiceCollection services)
        { 
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IRabbitMQService, RabbitMQService>();
        }
    }
}
