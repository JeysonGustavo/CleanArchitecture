﻿using CleanArchitecture.Application.Common.App;
using CleanArchitecture.Application.Common.ErrorMessage;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Messaging.Command;
using CleanArchitecture.Application.Repositories.Career;

namespace CleanArchitecture.Application.Features.Career.Commands.DeleteCareer
{
    internal sealed class DeleteCareerCommandHandler(ICareerRepository careerRepository) : ICommandHandler<DeleteCareerCommand>
    {
        #region Properties
        private readonly ICareerRepository _careerRepository = careerRepository;
        #endregion

        #region Handle
        public async Task<ApplicationResult> Handle(DeleteCareerCommand command, CancellationToken cancellationToken)
        {
            if (command.Id < 1)
                throw new BadRequestException(DefaultErrorMessages.CAREER_ID_IS_REQUIRED);

            _ = await _careerRepository.GetCareerByIdAsync(command.Id) ?? throw new NotFoundException(DefaultErrorMessages.CAREER_NOT_FOUND);

            var response = await _careerRepository.DeleteCareerAsync(command.Id);

            return ApplicationResult.Success(response);
        }
        #endregion
    }
}
