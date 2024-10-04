using AspNetCoreRateLimit;

namespace CleanArchitecture.API.Configuration
{
    public static class APIRateLimitConfiguration
    {
        #region AddRateLimitConfiguration
        public static void AddRateLimitConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddMemoryCache();
            services.Configure<ClientRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            services.Configure<ClientRateLimitPolicies>(configuration.GetSection("IpRateLimiting"));
            services.AddInMemoryRateLimiting();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
        #endregion

        #region UseRateLimitConfiguration
        public static void UseRateLimitConfiguration(this IApplicationBuilder app)
        {
            app.UseIpRateLimiting();
        }
        #endregion
    }
}
