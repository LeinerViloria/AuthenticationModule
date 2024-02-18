
using AuthenticationModule.Access;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Repository
{
    public class LoginRepository
    {
        private readonly IDbContextFactory<AuthenticationContext> _dbContextFactory;
        public LoginRepository(IDbContextFactory<AuthenticationContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Login()
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                
            }
        }
    }
}