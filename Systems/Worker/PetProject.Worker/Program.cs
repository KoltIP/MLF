// Configure application
using PetProject.Settings.Settings;
using PetProject.Settings.Sourse;
using PetProject.Worker;
using PetProject.Worker.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Settings for the initial configuration
var settings = new WorkerSettings(new SettingsSource());

// Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(logger, true);

// Configure services
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppHealthCheck();
services.RegisterServices();


// Start application

var app = builder.Build();

app.UseAppHealthCheck();

app.StartTaskExecutor();

app.Run();