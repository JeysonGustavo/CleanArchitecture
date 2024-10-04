using CleanArchitecture.Application.Data.UnitOfWork;
using CleanArchitecture.Infrastructure.Data.DBSession;

namespace CleanArchitecture.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork(ApplicationDBSession dbSession) : IUnitOfWork
    {
        #region Properties
        private readonly ApplicationDBSession _dbSession = dbSession;
        #endregion

        #region BeginTransaction
        public void BeginTransaction() => _dbSession.Transaction = _dbSession.Connection.BeginTransaction();
        #endregion

        #region Commit
        public void Commit()
        {
            _dbSession.Transaction?.Commit();
            Dispose();
        }
        #endregion

        #region Rollback
        public void Rollback()
        {
            _dbSession.Transaction?.Rollback();
            Dispose();
        }
        #endregion

        #region Dispose
        public void Dispose() => _dbSession.Transaction?.Dispose();
        #endregion
    }
}
