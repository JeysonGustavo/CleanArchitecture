﻿namespace CleanArchitecture.API.Configuration
{
    public static class NWebSecConfiguration
    {
        #region UseNWebsecConfiguration
        public static void UseNWebsecConfiguration(this IApplicationBuilder app)
        {
            app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains().Preload());
            app.UseXContentTypeOptions();
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseXfo(options => options.SameOrigin());
            app.UseReferrerPolicy(opts => opts.NoReferrerWhenDowngrade());



            app.UseCsp(options => options
               .BlockAllMixedContent()
               .StyleSources(s => s.Self())
               .StyleSources(s => s.UnsafeInline())
               .FontSources(s => s.Self())
               .FormActions(s => s.Self())
               .FrameAncestors(s => s.Self())
               .ImageSources(s => s.Self())
               .ScriptSources(s => s.Self())
            );
        }
        #endregion
    }
}
