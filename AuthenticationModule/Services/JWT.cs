
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AuthenticationModule.DTOS;
using AuthenticationModule.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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

        public string Generate(User? obj)
        {
            if(obj is null)
                return string.Empty;

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
                    new Claim("user", JsonConvert.SerializeObject(JwtUser, Formatting.None))
                }),
                Expires = DateTime.UtcNow.AddMinutes(MinutesExp),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
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