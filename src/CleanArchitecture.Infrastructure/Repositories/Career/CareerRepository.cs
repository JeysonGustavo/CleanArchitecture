using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Contracts.Request.Career;
using CleanArchitecture.Application.Contracts.Response.Career;
using CleanArchitecture.Application.Repositories.Career;
using CleanArchitecture.Domain.Entities.Career;
using CleanArchitecture.Infrastructure.Data.DBSession;
using CleanArchitecture.Infrastructure.Repositories.Common;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories.Career
{
    public class CareerRepository(ApplicationDBSession dbSession, IOptions<AppSettings> appSettings) : BaseRepository(dbSession, appSettings), ICareerRepository
    {
        #region CreateCareerAsync
        public async Task<CareerEntity> CreateCareerAsync(CareerEntity career)
        {
            DynamicParameters dynamicParameters = new();

            string sql = """
                INSERT INTO tblCareer
                (Language, Title, Introduction, Description, Location, CreatedOn, LastModifiedOn)

                OUTPUT INSERTED.Id

                VALUES
                (@Language, @Title, @Introduction, @Description, @Location, GETDATE(), GETDATE())
                """;

            dynamicParameters.Add("@Language", career.Language, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LANGUAGE);
            dynamicParameters.Add("@Title", career.Title, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_TITLE);
            dynamicParameters.Add("@Introduction", career.Introduction, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_INTRODUCTION);
            dynamicParameters.Add("@Description", career.Description, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_DESCRIPTION);
            dynamicParameters.Add("@Location", career.Location, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LOCATION);

            career.SetId(await _dbSession.Connection.ExecuteScalarAsync<int>(sql: sql, param: dynamicParameters, transaction: _dbSession.Transaction));

            return career;
        }
        #endregion

        #region UpdateCareerAsync
        public async Task<bool> UpdateCareerAsync(CareerEntity career)
        {
            DynamicParameters dynamicParameters = new();

            string sql = """
                UPDATE tblCareer
                   SET
                      Language = @Language
                    , Title = @Title
                    , Introduction = @Introduction
                    , Description = @Description
                    , Location = @Location
                    , LastModifiedOn = GETDATE()
                WHERE Id = @Id
                """;

            dynamicParameters.Add("@Language", career.Language, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LANGUAGE);
            dynamicParameters.Add("@Title", career.Title, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_TITLE);
            dynamicParameters.Add("@Introduction", career.Introduction, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_INTRODUCTION);
            dynamicParameters.Add("@Description", career.Description, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_DESCRIPTION);
            dynamicParameters.Add("@Location", career.Location, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LOCATION);
            dynamicParameters.Add("@Id", career.Id, DbType.Int32, ParameterDirection.Input);

            return await _dbSession.Connection.ExecuteAsync(sql: sql, param: dynamicParameters, transaction: _dbSession.Transaction) > 0;
        }
        #endregion

        #region DeleteCareerAsync
        public async Task<bool> DeleteCareerAsync(int id)
        {
            DynamicParameters dynamicParameters = new();

            string sql = """
                DELETE
                FROM tblCareer
                WHERE Id = @Id
                """;

            dynamicParameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            return await _dbSession.Connection.ExecuteAsync(sql: sql, param: dynamicParameters, transaction: _dbSession.Transaction) > 0;
        }
        #endregion

        #region GetCareerByIdAsync
        public async Task<CareerResponse?> GetCareerByIdAsync(int id)
        {
            DynamicParameters dynamicParameters = new();

            string sql = """
                SELECT C.Id
                     , C.Language
                     , C.Title
                     , C.Introduction
                     , C.Description
                     , C.Location
                     , COUNT(1) OVER() AS TotalRecords
                FROM tblCareer C
                WHERE C.Id = @Id
                """;

            dynamicParameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            return await _dbSession.Connection.QueryFirstOrDefaultAsync<CareerResponse?>(sql: sql, param: dynamicParameters, transaction: _dbSession.Transaction);
        }
        #endregion

        #region GetCarrersListAsync
        public async Task<IEnumerable<CareerResponse>> GetCarrersListAsync(CareerFilterListRequest request)
        {
            StringBuilder sqlBuilder = new();
            DynamicParameters dynamicParameters = new();

            sqlBuilder.AppendLine(" SELECT C.Id ");
            sqlBuilder.AppendLine("      , C.Language ");
            sqlBuilder.AppendLine("      , C.Title ");
            sqlBuilder.AppendLine("      , C.Introduction ");
            sqlBuilder.AppendLine("      , C.Description ");
            sqlBuilder.AppendLine("      , C.Location ");
            sqlBuilder.AppendLine("      , COUNT(1) OVER() AS TotalRecords ");
            sqlBuilder.AppendLine(" FROM tblCareer C ");
            sqlBuilder.AppendLine(" WHERE 1 = 1 ");

            #region Filters
            if (string.IsNullOrEmpty(request.Language) is false)
            {
                sqlBuilder.AppendLine("   AND C.Language = @Language ");
                dynamicParameters.Add("@Language", request.Language, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LANGUAGE);
            }

            if (string.IsNullOrEmpty(request.Location) is false)
            {
                sqlBuilder.AppendLine("   AND C.Location = @Location ");
                dynamicParameters.Add("@Location", request.Location, DbType.AnsiString, ParameterDirection.Input, CareerEntity.MAX_LENGTH_LOCATION);
            }

            if (request.LastModifiedOnFrom.HasValue)
            {
                sqlBuilder.AppendLine("   AND CONVERT(DATE, C.LastModifiedOn) >= CONVERT(DATE, @LastModifiedOnFrom) ");
                dynamicParameters.Add("@LastModifiedOnFrom", request.LastModifiedOnFrom, DbType.DateTime, ParameterDirection.Input);
            }

            if (request.LastModifiedOnTo.HasValue)
            {
                sqlBuilder.AppendLine("   AND CONVERT(DATE, C.LastModifiedOn) <= CONVERT(DATE, @LastModifiedOnTo) ");
                dynamicParameters.Add("@LastModifiedOnTo", request.LastModifiedOnTo, DbType.DateTime, ParameterDirection.Input);
            }
            #endregion

            sqlBuilder.AppendLine(" ORDER BY C.LastModifiedOn DESC ");
            sqlBuilder.AppendLine(" OFFSET @StartSelection ");
            sqlBuilder.AppendLine(" ROWS FETCH NEXT @PageSize ROWS ONLY ");

            dynamicParameters.Add("@StartSelection", request.StartSelection, DbType.Int32, ParameterDirection.Input);
            dynamicParameters.Add("@PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            return await _dbSession.Connection.QueryAsync<CareerResponse>(sql: sqlBuilder.ToString(), param: dynamicParameters, transaction: _dbSession.Transaction);
        }
        #endregion
    }
}
