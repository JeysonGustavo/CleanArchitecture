using CleanArchitecture.Domain.Data.DBSession;
using CleanArchitecture.Domain.Data.UnitOfWork;

namespace CleanArchitecture.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork(DBSession dbSession) : IUnitOfWork
    {
        #region Properties
        private readonly DBSession _dbSession = dbSession;
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
