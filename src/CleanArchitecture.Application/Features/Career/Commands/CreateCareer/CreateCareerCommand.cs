using CleanArchitecture.Application.Common.ErrorMessage;
using CleanArchitecture.Application.Common.Messaging.Command;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Career.Commands.CreateCareer
{
    public sealed record CreateCareerCommand : ICommand
    {
        #region Properties
        public string Language { get; private set; }
        public string Title { get; private set; }
        public string Introduction { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        #endregion

        #region Constructor
        public CreateCareerCommand(string language, string title, string introduction, string description, string location)
        {
            Language = language;
            Title = title;
            Introduction = introduction;
            Description = description;
            Location = location;
        }
        #endregion

        #region Validator
        public sealed class CreateCareerCommandValidator : AbstractValidator<CreateCareerCommand>
        {
            public CreateCareerCommandValidator()
            {
                RuleFor(x => x.Language)
                    .NotEmpty().When(x => string.IsNullOrEmpty(x.Language))
                    .WithErrorCode("1")
                    .WithMessage(DefaultErrorMessages.LANGUAGE_IS_REQUIRED);

                RuleFor(x => x.Title)
                   .NotEmpty().When(x => string.IsNullOrEmpty(x.Title))
                   .WithErrorCode("2")
                   .WithMessage(DefaultErrorMessages.TITLE_IS_REQUIRED);

                RuleFor(x => x.Description)
                   .NotEmpty().When(x => string.IsNullOrEmpty(x.Description))
                   .WithErrorCode("3")
                   .WithMessage(DefaultErrorMessages.DESCRIPTION_IS_REQUIRED);
            }
        }
        #endregion
    }
}
