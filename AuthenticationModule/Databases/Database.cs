
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Databases
{
    public interface IDatabase
    {
        void SetConnection();
    }
    
    public abstract class Database : IDatabase
    {
        protected readonly IServiceProvider provider;
        protected readonly string ConnectionString;
        protected readonly DbContextOptionsBuilder dbContextOptions;
        protected Database(IServiceProvider serviceProvider, DbContextOptionsBuilder options, string Connection)
        {
            provider = serviceProvider;
            dbContextOptions = options;
            ConnectionString = Connection;
        }

        public abstract void SetConnection();
    }
}