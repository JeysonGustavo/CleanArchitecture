using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Contracts.Response.Career;
using CleanArchitecture.Application.Messaging.Command;
using CleanArchitecture.Application.Repositories.Career;
using CleanArchitecture.Domain.Entities.Career;
using Mapster;

namespace CleanArchitecture.Application.Features.Career.Commands.CreateCareer
{
    internal sealed class CreateCareerCommandHandler(ICareerRepository careerRepository) : ICommandHandler<CreateCareerCommand>
    {
        #region Properties
        private readonly ICareerRepository _careerRepository = careerRepository;
        #endregion

        #region Handle
        public async Task<ApplicationResult> Handle(CreateCareerCommand command, CancellationToken cancellationToken)
        {
            var career = command.Adapt<CareerEntity>();

            career = await _careerRepository.CreateCareerAsync(career);

            var response = career.Adapt<CareerResponse>();

            return ApplicationResult.Success(response);
        }
        #endregion
    }
}
