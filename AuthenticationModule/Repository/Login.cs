
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
                Password = Utils.HashTo256(Obj.Password, _tokenConfiguration.Salt)
            };

            var Errors = new List<ValidationResult>();

            var IsValid = DataAnnotationsValidator.Validate<User>(NewUser, ref Errors);

            if(!IsValid)
                throw new Exception(JsonSerializer.Serialize(Errors.Select(x => x.ErrorMessage)));

            using(var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Add(NewUser);
                dbContext.SaveChanges();
            }

            // var Token = _jWTService.Generate(NewUser);
            // return Token;
            return "";
        }
    }
}