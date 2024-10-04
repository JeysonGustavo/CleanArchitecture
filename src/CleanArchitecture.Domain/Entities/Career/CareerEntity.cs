using CleanArchitecture.Domain.Common.Entities;
using FluentValidation;

namespace CleanArchitecture.Domain.Entities.Career
{
    public class CareerEntity : BaseEntity
    {
        #region Properties
        public const int MAX_LENGTH_LANGUAGE = 50;
        public const int MAX_LENGTH_TITLE = 100;
        public const int MAX_LENGTH_INTRODUCTION = 1000;
        public const int MAX_LENGTH_DESCRIPTION = 1000;
        public const int MAX_LENGTH_LOCATION = 100;

        public string Language { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Introduction { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
        #endregion

        #region Constructor
        public CareerEntity(string language, string title, string introduction, string description, string location)
        {
            Language = language;
            Title = title;
            Introduction = introduction;
            Description = description;
            Location = location;

            Validate();
        }

        public CareerEntity(int id, string language, string title, string introduction, string description, string location)
        {
            SetId(id);
            Language = language;
            Title = title;
            Introduction = introduction;
            Description = description;
            Location = location;

            Validate();
        }
        #endregion

        #region Validate
        public override void Validate()
        {
            ValidationResult = new CareerValidator().Validate(this);

            ValidateEntity();
        }
        #endregion

        #region Validator
        public sealed class CareerValidator : AbstractValidator<CareerEntity>
        {
            public CareerValidator()
            {
                RuleFor(x => x.Language)
                    .NotEmpty().When(x => string.IsNullOrEmpty(x.Language))
                    .WithErrorCode("1")
                    .WithMessage($"{{PropertyName}} cannot be empty");

                RuleFor(x => x.Language)
                    .MaximumLength(MAX_LENGTH_LANGUAGE)
                    .WithErrorCode("2")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {MAX_LENGTH_LANGUAGE}");

                RuleFor(x => x.Title)
                    .NotEmpty().When(x => string.IsNullOrEmpty(x.Title))
                    .WithErrorCode("3")
                    .WithMessage($"{{PropertyName}} cannot be empty");

                RuleFor(x => x.Title)
                    .MaximumLength(MAX_LENGTH_TITLE)
                    .WithErrorCode("4")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {MAX_LENGTH_TITLE}");

                RuleFor(x => x.Introduction)
                    .MaximumLength(MAX_LENGTH_INTRODUCTION)
                    .WithErrorCode("5")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {MAX_LENGTH_INTRODUCTION}");

                RuleFor(x => x.Description)
                   .NotEmpty().When(x => string.IsNullOrEmpty(x.Description))
                   .WithErrorCode("6")
                   .WithMessage($"{{PropertyName}} cannot be empty");

                RuleFor(x => x.Description)
                    .MaximumLength(MAX_LENGTH_DESCRIPTION)
                    .WithErrorCode("7")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {MAX_LENGTH_DESCRIPTION}");

                RuleFor(x => x.Location)
                    .MaximumLength(MAX_LENGTH_LOCATION)
                    .WithErrorCode("8")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {MAX_LENGTH_LOCATION}");
            }
        }
        #endregion
    }
}
