
using AuthenticationModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationModule.Access
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<User> User {get; set;}
    }
}