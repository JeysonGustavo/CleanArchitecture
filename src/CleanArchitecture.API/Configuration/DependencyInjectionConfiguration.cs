using CleanArchitecture.Application.Data.UnitOfWork;
using CleanArchitecture.Application.Repositories.Career;
using CleanArchitecture.Infrastructure.Data.DBSession;
using CleanArchitecture.Infrastructure.Data.UnitOfWork;
using CleanArchitecture.Infrastructure.Repositories.Career;

namespace CleanArchitecture.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        #region AddDependencyInjectionConfiguration
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<ICareerRepository, CareerRepository>();
            #endregion

            #region Connection
            services.AddScoped<ApplicationDBSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }
        #endregion
    }
}
