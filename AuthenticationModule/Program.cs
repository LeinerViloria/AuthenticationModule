using Authentication.Utilities;
using AuthenticationModule;
using AuthenticationModule.Access;
using AuthenticationModule.DTOS;
using AuthenticationModule.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExtensions(builder.Configuration);
builder.Services.MigrateDatabase<AuthenticationContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/login", (IServiceProvider provider, UserDTO Data) =>
{
    try
    {
        var Login = ActivatorUtilities.CreateInstance<LoginRepository>(provider);
        var Result = new ActionResult<string>(){
            Success = true,
            Data = Login.Login(Data)
        };
        return Result;
    }
    catch (Exception e)
    {
        var Error = new ActionResult<string>(){
            Error = "Invalid credentials"
        };
        return Error;
    }
}).WithName("LogIn")
.WithOpenApi();

app.MapPost("/register", (IServiceProvider provider, UserDTO Data) =>
{
   try
   {
        var Login = ActivatorUtilities.CreateInstance<LoginRepository>(provider);
        var Result = new ActionResult<string>(){
            Success = true,
            Data = Login.Register(Data)
        };
        return Result;
   }
   catch (Exception e)
   {
        var Error = new ActionResult<string>(){
            Error = string.IsNullOrEmpty($"{e.InnerException}") ?
            e.Message : $"{e.InnerException}"
        };
        return Error;
   }
}).WithName("SignUp")
.WithOpenApi();

app.MapPost("/validatetoken", (IServiceProvider provider, HttpContext Context) => 
{
    try
   {
        var Token = Context.Request.Headers.Authorization.First()!.Split(' ')[1];
        var Login = ActivatorUtilities.CreateInstance<LoginRepository>(provider);
        var Result = new ActionResult<JWTUserDTO>(){
            Success = true,
            Data = Login.ValidateToken(Token)
        };
        return Result;
   }
   catch (Exception e)
   {
        var Error = new ActionResult<JWTUserDTO>(){
            Error = "Invalid token"
        };
        return Error;
   }
}).WithName("ValidateToken")
.WithOpenApi();

app.Run();
