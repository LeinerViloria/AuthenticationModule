

using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Databases
{
    public class MySql : Database
    {
        public MySql(IServiceProvider serviceProvider, string Connection) : base(serviceProvider, Connection)
        {
        }

        public override void SetConnection(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }
    }
}