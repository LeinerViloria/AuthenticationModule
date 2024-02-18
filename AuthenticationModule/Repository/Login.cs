
using AuthenticationModule.Access;
using AuthenticationModule.DTOS;
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

        public string Register(UserToCreateDTO Obj)
        {
            var Token = "Token X";
            return Token;
        }
    }
}