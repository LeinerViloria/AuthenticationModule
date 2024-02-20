
namespace AuthenticationModule.Services
{
    public interface IDatabaseConfiguration
    {
        string Provider {get; set;}
        string Connection {get; set;}
    }

    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string Provider {get; set;} = string.Empty;
        public string Connection {get; set;} = string.Empty;
    }
}