using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public interface IORMTypes
    {
        IServiceCollection Resolver(IServiceCollection services, IConfiguration configuration = null);
    }
}
