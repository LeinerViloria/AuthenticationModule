
namespace AuthenticationModule.DTOS
{
    public class ActionResult<T>
    {
        public bool Success {get; set;}
        public T Data {get; set;}
        public string Error {get; set;}
    }
}