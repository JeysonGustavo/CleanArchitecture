using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Contracts.Response.Career;
using CleanArchitecture.Application.Messaging.Query;
using CleanArchitecture.Application.Repositories.Career;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCarrersList
{
    internal sealed class GetCarrersListQueryHandler(ICareerRepository careerRepository) : IQueryHandler<GetCarrersListQuery>
    {
        #region Properties
        private readonly ICareerRepository _careerRepository = careerRepository;
        #endregion

        #region Handle
        public async Task<ApplicationResult> Handle(GetCarrersListQuery query, CancellationToken cancellationToken)
        {
            var response = await _careerRepository.GetCarrersListAsync(query.Request);

            return ApplicationResult.Success(response ?? new List<CareerResponse>());
        }
        #endregion
    }
}