using Microsoft.OpenApi.Models;
using RadancyBanking.Services;
using RadancyBanking.Services.Implementations;
using RadancyBanking.Services.Validation;
using RadancyBanking.Services.Validation.Implementations;
using RandacyBanking.Repositories;
using RandacyBanking.Repositories.Implementations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Radancy Banking API",
        Description = "Radancy Banking API to add users, and add, transact, and delete user accounts.",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddHealthChecks();

builder.Services.AddTransient<IAccountService, AccountService>()
    .AddTransient<IUserService, UserService>()
    .AddTransient<IAccountRepository, AccountRepository>()
    .AddTransient<IUserRepository, UserRepository>()
    .AddTransient<IValidatorFactory, ValidatorFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI((options =>
    {
        options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    }));
}

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
