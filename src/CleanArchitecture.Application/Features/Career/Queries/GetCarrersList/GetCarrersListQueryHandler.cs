using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Contracts.Request.Career;
using CleanArchitecture.Application.Messaging.Query;
using CleanArchitecture.Application.Repositories.Career;
using Mapster;

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
            var request = query.Adapt<CareerListRequest>();

            var response = await _careerRepository.GetCarrersListAsync(request);

            return ApplicationResult.WithSuccess(response);
        }
        #endregion
    }
}