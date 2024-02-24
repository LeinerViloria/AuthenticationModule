

using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Databases
{
    public class Postgresql : Database
    {
        public Postgresql(IServiceProvider serviceProvider, DbContextOptionsBuilder dbContextOptions, string Connection) : base(serviceProvider, dbContextOptions, Connection)
        {
        }

        public override void SetConnection()
        {
            dbContextOptions.UseNpgsql(ConnectionString);
        }
    }
}