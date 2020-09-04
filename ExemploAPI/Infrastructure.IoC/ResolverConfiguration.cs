using Infrastructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.IoC
{
    internal class ResolverConfiguration
    {
        public static IConfiguration GetConfigurationSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
