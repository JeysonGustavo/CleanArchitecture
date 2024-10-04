using CleanArchitecture.Application.Contracts.Response.Career;
using CleanArchitecture.Domain.Common.App;
using CleanArchitecture.Domain.Entities.Career;
using CleanArchitecture.Domain.Messaging.Command;
using CleanArchitecture.Domain.Repositories.Career;
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

            career = await _careerRepository.CreateCareer(career);

            var response = career.Adapt<CareerResponse>();

            return new ApplicationResult().WithSuccess(response);
        }
        #endregion
    }
}
