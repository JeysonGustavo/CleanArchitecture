using CleanArchitecture.Domain.Common.App;
using CleanArchitecture.Domain.Data.DBSession;
using CleanArchitecture.Domain.Entities.Career;
using CleanArchitecture.Domain.Repositories.Career;
using CleanArchitecture.Infrastructure.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories.Career
{
    public class CareerRepository(DBSession dbSession, IOptions<AppSettings> appSettings) : BaseRepository(dbSession, appSettings), ICareerRepository
    {
        #region CreateCareer
        public async Task<CareerEntity> CreateCareer(CareerEntity career)
        {
            StringBuilder sqlBuilder = new();
            DynamicParameters dynamicParameters = new();

            sqlBuilder.AppendLine(" INSERT INTO tblCareer ");
            sqlBuilder.AppendLine(" (Language, Title, Introduction, Description, Location, CreatedOn, LastModifiedOn) ");

            sqlBuilder.AppendLine(" OUTPUT INSERTED.Id ");

            sqlBuilder.AppendLine(" VALUES ");
            sqlBuilder.AppendLine(" (@Language, @Title, @Introduction, @Description, @Location, GETDATE(), GETDATE()) ");

            dynamicParameters.Add("@Language", career.Language, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LANGUAGE);
            dynamicParameters.Add("@Title", career.Title, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_TITLE);
            dynamicParameters.Add("@Introduction", career.Introduction, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_INTRODUCTION);
            dynamicParameters.Add("@Description", career.Description, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_DESCRIPTION);
            dynamicParameters.Add("@Location", career.Location, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LOCATION);

            career.SetId(await _dbSession.Connection.ExecuteScalarAsync<int>(sql: sqlBuilder.ToString(), param: dynamicParameters, transaction: _dbSession.Transaction));

            return career;
        } 
        #endregion
    }
}
