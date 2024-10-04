using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Infrastructure.Data.DBSession;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Repositories.Common
{
    public abstract class BaseRepository(ApplicationDBSession dbSession, IOptions<AppSettings> appSettings)
    {
        #region Properties
        public readonly ApplicationDBSession _dbSession = dbSession;
        public readonly AppSettings _appSettings = appSettings.Value;
        #endregion
    }
}
