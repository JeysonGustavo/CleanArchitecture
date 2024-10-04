using CleanArchitecture.Domain.Common.App;
using CleanArchitecture.Domain.Data.DBSession;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository(DBSession dbSession, IOptions<AppSettings> appSettings)
    {
        #region Properties
        public readonly DBSession _dbSession = dbSession;
        public readonly AppSettings _appSettings = appSettings.Value;
        #endregion
    }
}
