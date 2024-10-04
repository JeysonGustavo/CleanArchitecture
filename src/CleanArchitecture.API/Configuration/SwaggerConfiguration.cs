using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArchitecture.API.Configuration
{
    public static class SwaggerConfiguration
    {
        #region AddSwaggerConfiguration
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture API",
                    Description = "Clean Architecture",
                    Contact = new OpenApiContact
                    {
                        Name = "Jeyson Gomes github",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/JeysonGustavo"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //var securitySchema = new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer",
                //    Reference = new OpenApiReference
                //    {
                //        Type = ReferenceType.SecurityScheme,
                //        Id = "Bearer"
                //    }
                //};
                //c.AddSecurityDefinition("Bearer", securitySchema);

                //var securityRequirement = new OpenApiSecurityRequirement();
                //securityRequirement.Add(securitySchema, new[] { "Bearer" });
                //c.AddSecurityRequirement(securityRequirement);
            });

            services.AddEndpointsApiExplorer();
        }
        #endregion

        #region UseSwaggerConfiguration
        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Clean Architecture API V1");

                if (env.IsProduction())
                    c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { });
            });
        }
        #endregion
    }
}
