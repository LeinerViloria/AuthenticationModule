
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Databases
{
    public abstract class Database : IDatabase
    {
        protected readonly IServiceProvider provider;
        protected readonly string ConnectionString;
        protected Database(IServiceProvider serviceProvider, string Connection)
        {
            provider = serviceProvider;
            ConnectionString = Connection;
        }

        public abstract void SetConnection(DbContextOptionsBuilder dbContextOptions);
    }
}