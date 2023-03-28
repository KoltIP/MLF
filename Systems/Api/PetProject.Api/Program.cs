

using Microsoft.Extensions.FileProviders;
using PetProject.Api;
using PetProject.Api.Configuration;
using PetProject.Settings.Settings;
using PetProject.Settings.Sourse;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration
    .Enrich.WithCorrelationId()
    .ReadFrom.Configuration(hostBuilderContext.Configuration);
});



var settings = new ApiSettings(new SettingsSource());



var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(settings);

services.AddAppHealthCheck();

services.AddAppVersions();

services.AddAppSwagger(settings);

services.AddAppCors();

services.AddAppAuth(settings);

services.AddAppServices();

services.AddControllers().AddValidator();

services.AddRazorPages();

services.AddAutoMappers();

var app = builder.Build();


Log.Information("Start");

app.UseMiddlewares();

//app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});
//app.UseStaticFiles();

app.UseRouting();

app.UseAppCors();

app.UseAppHealthCkeck();

app.UseSerilogRequestLogging();

app.UseAppSwagger();

app.UseAppAuth();

app.MapRazorPages();

app.MapControllers();

app.UseAppDbContext();

app.Run();
