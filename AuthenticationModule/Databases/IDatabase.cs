
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Databases
{
    public interface IDatabase
    {
        void SetConnection(DbContextOptionsBuilder dbContextOptions);
    }
}