
using Microsoft.EntityFrameworkCore;

namespace Authentication.Utilities;

public static class WebHostUtils
{
    public static IServiceCollection MigrateDatabase<T>(this IServiceCollection services) where T : DbContext
    {
        var scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>()!;

      using (var scope = scopeFactory.CreateScope())
      {
        var service = scope.ServiceProvider;
        try
        {
          var db = service.GetRequiredService<T>();
          db.Database.Migrate();
        }
        catch (Exception ex)
        {
          var logger = service.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, "An error occurred while migrating the database.");
        }
      }
      return services;
    }
}