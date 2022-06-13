using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApiMySQL.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_AllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5533");
        }
       );
});
// MySQL connection string
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
var connString = builder.Configuration.GetConnectionString("WebApiMySQLContext");
builder.Services.AddDbContext<WebApiMySQLContext>(options =>
    options
        .UseMySql(connString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
        );

// SqLite Connection
//var connectionString = new SqliteConnectionStringBuilder { DataSource = "myDB.db" };
//var connection = new SqliteConnection(connectionString.ToString());
//builder.Services.AddDbContext<WebApiMySQLContext>(options => options.UseSqlite(connection));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("_AllowedOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
