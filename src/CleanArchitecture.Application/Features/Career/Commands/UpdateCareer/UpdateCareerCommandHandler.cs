using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Common.ErrorMessage;
using CleanArchitecture.Application.Common.Exceptions;
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
            _ = await _carrerRepository.GetCareerByIdAsync(command.Id) ?? throw new NotFoundException(DefaultErrorMessages.CAREER_NOT_FOUND);
            
            var career = command.Adapt<CareerEntity>();

            var response = await _carrerRepository.UpdateCareerAsync(career);

            return ApplicationResult.Success(response);
        }
        #endregion
    }
}