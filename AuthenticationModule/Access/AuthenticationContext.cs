
using AuthenticationModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Access
{
    public class AuthenticationContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> User {get; set;}
    }
}