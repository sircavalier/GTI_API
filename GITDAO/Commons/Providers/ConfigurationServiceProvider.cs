using Microsoft.Extensions.Configuration;

namespace GITDAO.Commons.Providers
{
    public static class ConfigurationServiceProvider
    {
        static IConfiguration configurationService = null;

        public static void SetConfigurationService(IConfiguration service)
        {
            configurationService = service;
        }

        public static string GetConfigurationKey(string key)
        {
            return configurationService.GetSection(key).Value;
        }

        public static string GetConfiguration(string section, string key)
        {
            return configurationService.GetSection(section)[key];
        }

        public static string GetConnectionString(string key)
        {
            return configurationService.GetConnectionString(key);
        }
    }
}