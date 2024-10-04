using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace CleanArchitecture.API.Configuration
{
    public static class CompressionConfiguration
    {
        #region AddCompressionConfiguration
        public static void AddCompressionConfiguration(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    var serializerOptions = options.JsonSerializerOptions;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
        }
        #endregion
    }
}
