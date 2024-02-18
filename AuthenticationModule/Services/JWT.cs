
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AuthenticationModule.DTOS;
using AuthenticationModule.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationModule.Services
{
    public interface IJWTService
    {
        public string Generate(User obj);

        public T Validate<T>(string token);
    }

    public class JWTService : IJWTService
    {
        readonly string Salt;
        readonly string SecretKey;
        readonly int MinutesExp;

        public JWTService(IOptions<TokenConfiguration> options)
        {
            Salt = options.Value.Salt;
            SecretKey = options.Value.Secret;
            MinutesExp = options.Value.MinutesExp;
        }

        public string Generate(User obj)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var JwtUser = new JWTUserDTO()
            {
                Rowid = obj.Rowid,
                Email = obj.Email
            };

            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("user", JsonSerializer.Serialize(JwtUser))
                }),
                Expires = DateTime.UtcNow.AddMinutes(MinutesExp),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.Aes256CbcHmacSha512
                )
            };

            var Value = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(Value);
        }

        public T Validate<T>(string token)
        {
            throw new NotImplementedException();
        }
    }
}