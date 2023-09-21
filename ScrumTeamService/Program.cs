using Microsoft.Extensions.Options;
using ScrumTeamService.Extensions;
using ScrumTeamService.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();
builder.Services.RegisterValidators();
builder.Services.Configure<ConfigurationOptions>(builder.Configuration.GetSection(nameof(ConfigurationOptions)));

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
builder.Logging.AddSerilog(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || string.Equals(
        app.Environment.EnvironmentName,
        "LocalDevelopment",
        StringComparison.OrdinalIgnoreCase))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();