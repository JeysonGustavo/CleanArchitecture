using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Common.ErrorMessage;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Messaging.Query;
using CleanArchitecture.Application.Repositories.Career;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCareerById
{
    internal sealed class GetCareerByIdQueryHandler(ICareerRepository careerRepository) : IQueryHandler<GetCareerByIdQuery>
    {
        #region Properties
        private readonly ICareerRepository _careerRepository = careerRepository;
        #endregion

        #region Handle
        public async Task<ApplicationResult> Handle(GetCareerByIdQuery query, CancellationToken cancellationToken)
        {
            if (query.Id < 1)
                throw new BadRequestException(DefaultErrorMessages.CAREER_ID_IS_REQUIRED);

            var response = await _careerRepository.GetCareerByIdAsync(query.Id) ?? throw new NotFoundException(DefaultErrorMessages.CAREER_NOT_FOUND);

            return ApplicationResult.Success(response);
        } 
        #endregion
    }
}