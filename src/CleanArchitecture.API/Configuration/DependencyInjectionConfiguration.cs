using CleanArchitecture.Domain.Data.DBSession;
using CleanArchitecture.Domain.Data.UnitOfWork;
using CleanArchitecture.Domain.Repositories.Career;
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
            services.AddScoped<DBSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }
        #endregion
    }
}
