
using AuthenticationModule.Access;
using AuthenticationModule.DTOS;
using AuthenticationModule.Entities;
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
            var NewUser = new User()
            {
                CreationDate = DateTime.UtcNow,
                Email = Obj.Email,
                Password = Obj.Password
            };

            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Add(NewUser);
                context.SaveChanges();
            }

            var Token = "Token X";
            return Token;
        }
    }
}