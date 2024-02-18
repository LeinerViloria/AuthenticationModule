using AuthenticationModule;
using AuthenticationModule.DTOS;
using AuthenticationModule.Repository;
using AuthenticationModule.DTOS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExtensions(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/login", (IServiceProvider provider) =>
{
    var Login = ActivatorUtilities.CreateInstance<LoginRepository>(provider);
    Login.Login();
}).WithName("LogIn")
.WithOpenApi();

app.MapPost("/register", (IServiceProvider provider, UserToCreateDTO Data) =>
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

app.Run();
