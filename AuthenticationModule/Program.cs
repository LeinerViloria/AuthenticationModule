using AuthenticationModule;
using AuthenticationModule.DTOS;
using AuthenticationModule.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
    var Login = ActivatorUtilities.CreateInstance<LoginRepository>(provider);
    var Result = Login.Register(Data);
    return Result;
}).WithName("SignUp")
.WithOpenApi();

app.Run();
