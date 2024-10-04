namespace CleanArchitecture.API.Configuration
{
    public static class FeaturePolicyConfiguration
    {
        #region UseFeaturePolicyConfiguration
        public static void UseFeaturePolicyConfiguration(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");

                await next.Invoke();
            });
        }
        #endregion
    }
}
