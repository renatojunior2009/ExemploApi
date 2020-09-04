using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.IoC
{
    public static class ResolveOrm
    {
        public static void UseORM<T>(this IServiceCollection services, IConfiguration configuration = null) where T: IORMTypes, new()
        {
            var ormType = new T();
            ormType.Resolver(services, configuration);
        }
    }
}
