
using AuthenticationModule.Access;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace AuthenticationModule
{
    public static class Startup
    {
        public static void AddExtensions(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            var ConnectionString = configurationManager.GetConnectionString("Connection");

            Action<IServiceProvider, DbContextOptionsBuilder> DbContextOptions = (sp, options) => {
                options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
            };

            services.AddDbContextFactory<AuthenticationContext>(DbContextOptions, ServiceLifetime.Transient);
        }
    }
}