
using AuthenticationModule.Access;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Repository
{
    public class LoginRepository(IDbContextFactory<AuthenticationContext> dbContextFactory)
    {
        private readonly IDbContextFactory<AuthenticationContext> _dbContextFactory = dbContextFactory;

        public void Login()
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                
            }
        }

        public void Register()
        {
            
        }
    }
}