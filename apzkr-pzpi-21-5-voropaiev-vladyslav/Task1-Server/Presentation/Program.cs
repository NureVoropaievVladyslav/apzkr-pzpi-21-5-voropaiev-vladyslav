using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Presentation.Middleware;
using Presentation.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

// Add services to the container.

builder.Services.AddLocalization(opt => opt.ResourcesPath = "Cultures");
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.UseRequestLocalization(options =>
{
    options.SupportedCultures = [
        new CultureInfo("en-US"),
        new CultureInfo("uk-UA")
    ];
    options.SupportedUICultures = [
        new CultureInfo("en-US"),
        new CultureInfo("uk-UA")
    ];
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.RequestCultureProviders = [options.RequestCultureProviders.Last()];
});

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.MigrateContext();

app.Run();