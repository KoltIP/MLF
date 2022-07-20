using PetProject.Identity;
using PetProject.Identity.Configuration;
using PetProject.Settings.Settings;
using PetProject.Settings.Sourse;

var builder = WebApplication.CreateBuilder(args);

var settings = new IS4Settings(new SettingsSource());

var services = builder.Services;

services.AddAppCors();

services.AddAppDbContext(settings.Db);

services.AddHttpContextAccessor();

services.AddAppServices();

builder.Services.AddIS4();


//Start
var app = builder.Build();

app.UseAppCors();

app.UseStaticFiles();

app.UseRouting();

app.UseAppDbContext();

app.UseIS4();

app.Run();