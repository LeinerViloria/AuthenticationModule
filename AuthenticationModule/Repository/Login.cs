
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using AuthenticationModule.Access;
using AuthenticationModule.DTOS;
using AuthenticationModule.Entities;
using AuthenticationModule.Services;
using AuthenticationModule.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AuthenticationModule.Repository
{
    public class LoginRepository(IDbContextFactory<AuthenticationContext> dbContextFactory, IOptions<TokenConfiguration> options, IJWTService jwtService)
    {
        readonly IDbContextFactory<AuthenticationContext> _dbContextFactory = dbContextFactory;
        readonly ITokenConfiguration _tokenConfiguration = options.Value;
        readonly IJWTService _jWTService = jwtService;

        public string Login(UserDTO Obj)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                return "";
            }
        }

        public string Register(UserDTO Obj)
        {
            var NewUser = new User()
            {
                CreationDate = DateTime.UtcNow,
                Email = Obj.Email,
                Password = Obj.Password
            };

            var Errors = new List<ValidationResult>();

            var IsValid = DataAnnotationsValidator.Validate<User>(NewUser, ref Errors);

            if(!IsValid)
                throw new ArgumentNullException(JsonSerializer.Serialize(Errors.Select(x => x.ErrorMessage)));

            NewUser.Password = Utils.HashTo256(NewUser.Password, _tokenConfiguration.Salt);

            using(var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Add(NewUser);
                dbContext.SaveChanges();
            }

            var Token = _jWTService.Generate(NewUser);
            return Token;
        }
    }
}