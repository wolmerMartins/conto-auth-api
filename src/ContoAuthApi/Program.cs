using ContoAuthApi.Accounts.Repositories;
using ContoAuthApi.Accounts.Repositories.Models;
using ContoAuthApi.Accounts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

builder.Services.Configure<AccountsDatabaseSettings>(
    builder.Configuration.GetSection("AccountsDatabase"));
builder.Services.AddSingleton<IAccountsRepository, AccountsRepository>();
builder.Services.AddSingleton<IAccountsService, AccountsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
