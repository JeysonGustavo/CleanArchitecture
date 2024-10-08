using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Messaging.Command;
using CleanArchitecture.Application.Repositories.Career;
using CleanArchitecture.Domain.Entities.Career;
using Mapster;

namespace CleanArchitecture.Application.Features.Career.Commands.UpdateCareer
{
    public class UpdateCareerCommandHandler(ICareerRepository careerRepository) : ICommandHandler<UpdateCareerCommand>
    {
        #region Properties
        private readonly ICareerRepository _carrerRepository = careerRepository;
        #endregion

        #region Handle
        public async Task<ApplicationResult> Handle(UpdateCareerCommand command, CancellationToken cancellationToken)
        {
            var career = command.Adapt<CareerEntity>();

            var response = await _carrerRepository.UpdateCareerAsync(career);

            return ApplicationResult.WithSuccess(response);
        }
        #endregion
    }
}