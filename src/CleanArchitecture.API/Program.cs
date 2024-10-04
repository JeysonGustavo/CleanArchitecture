using CleanArchitecture.API.Configuration;
using CleanArchitecture.API.Endpoints.Career;
using CleanArchitecture.API.Mappers;
using CleanArchitecture.API.Middleware;
using CleanArchitecture.Application.Common.App;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

#region Services
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.Configure<ConnectionString>(configuration.GetSection("ConnectionString"));

builder.Services.AddCompressionConfiguration();

builder.Services.AddRateLimitConfiguration(configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDependencyInjectionConfiguration();

MappingProfile.ConfigureMapster();

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}

builder.Services.AddValidatorsFromAssembly(Assembly.Load("CleanArchitecture.Application"));

#endregion

var app = builder.Build();

#region Configure
app.UseSwaggerConfiguration(env);

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseDeveloperExceptionPage();

app.UseNWebsecConfiguration();

app.UseFeaturePolicyConfiguration();

app.UseResponseCompression();

app.UseStaticFiles();

app.UseRateLimitConfiguration();

app.UseMiddleware<ExceptionMiddleware>();
#endregion

#region Endpoints
app.ConfigureCareerEndpoints();
#endregion

app.Run();