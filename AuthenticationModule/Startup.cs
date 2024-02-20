
using AuthenticationModule.Access;
using AuthenticationModule.Databases;
using AuthenticationModule.Services;
using AuthenticationModule.Utilities;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace AuthenticationModule
{
    public static class Startup
    {
        public static void AddExtensions(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.Configure<TokenConfiguration>(configurationManager.GetSection("Authentication"));
            
            var Connection = configurationManager.GetSection("Connection").Get<DatabaseConfiguration>();

            var DbType = Utils.SearchType($"AuthenticationModule.Databases.{Connection!.Provider}");

            Action<IServiceProvider, DbContextOptionsBuilder> DbContextOptions = (sp, options) => {
                var DbInstance = (IDatabase) ActivatorUtilities.CreateInstance(sp, DbType!, options, Connection!.Connection);
                DbInstance.SetConnection();
            };

            services.AddDbContextFactory<AuthenticationContext>(DbContextOptions, ServiceLifetime.Transient);
            services.AddScoped<IJWTService, JWTService>();
        }
    }
}