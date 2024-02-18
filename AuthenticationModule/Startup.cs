
using AuthenticationModule.Access;
using AuthenticationModule.Services;
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
            services.AddScoped<IJWT, JWT>();
            services.Configure<TokenConfiguration>(configurationManager.GetSection("Authentication"));
           services.AddScoped<ITokenConfiguration, TokenConfiguration>();
        }
    }
}