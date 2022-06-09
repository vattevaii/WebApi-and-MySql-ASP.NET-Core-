using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiMySQL.Data;
using WebApiMySQL.Controllers;

var builder = WebApplication.CreateBuilder(args);

// MySQL connection string

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
var connString = builder.Configuration.GetConnectionString("WebApiMySQLContext");

builder.Services.AddDbContext<WebApiMySQLContext>(options =>
    options.UseMySql(connString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapVideoCollectionEndpoints();

app.Run();
