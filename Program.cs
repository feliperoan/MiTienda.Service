using Microsoft.OpenApi.Models;
using miTienda.Domain.Interfaces;
using miTienda.Domain.Services;
using miTienda.Infrastructure;
using miTienda.Infrastructure.Finders;
using miTienda.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi tienda Service", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
}); ;
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserFinder, UserFinder>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
