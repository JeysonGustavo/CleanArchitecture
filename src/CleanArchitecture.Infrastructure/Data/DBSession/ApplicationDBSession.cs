using CleanArchitecture.Application.Common.App;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace CleanArchitecture.Infrastructure.Data.DBSession
{
    public sealed class ApplicationDBSession : IDisposable
    {
        #region Properties
        private readonly IWebHostEnvironment _environment;
        public readonly ConnectionString _connectionString;
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }
        #endregion

        #region Constructor
        public ApplicationDBSession(IWebHostEnvironment environment, IOptions<ConnectionString> connectionString)
        {
            _environment = environment;
            _connectionString = connectionString.Value;
            Connection = new SqlConnection(GetConnectionString());
            Connection.Open();
        }
        #endregion

        #region Dispose
        public void Dispose() => Connection?.Dispose();
        #endregion

        #region Get Connection
        public string? GetConnectionString() =>
            _environment.EnvironmentName.Equals("Development") ? _connectionString.DBConnection : Environment.GetEnvironmentVariable("MyConnection_DB", EnvironmentVariableTarget.Machine);
        #endregion
    }
}
