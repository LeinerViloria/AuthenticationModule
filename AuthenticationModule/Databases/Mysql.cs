

using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Databases
{
    public class MySql : Database
    {
        public MySql(IServiceProvider serviceProvider, DbContextOptionsBuilder dbContextOptions, string Connection) : base(serviceProvider, dbContextOptions, Connection)
        {
        }

        public override void SetConnection()
        {
            dbContextOptions.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }
    }
}