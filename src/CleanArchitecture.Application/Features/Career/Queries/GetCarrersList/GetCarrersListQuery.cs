using CleanArchitecture.Application.Messaging.Query;
using CleanArchitecture.Domain.Entities.Career;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCarrersList
{
    public sealed record GetCarrersListQuery : IQuery
    {
        #region Properties
        public string Language { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
        public DateTime? LastModifiedOnFrom { get; private set; }
        public DateTime? LastModifiedOnTo { get; private set; }
        #endregion

        #region Constructor
        public GetCarrersListQuery(string language, string location, DateTime? lastModifiedOnFrom, DateTime? lastModifiedOnTo)
        {
            Language = language;
            Location = location;
            LastModifiedOnFrom = lastModifiedOnFrom;
            LastModifiedOnTo = lastModifiedOnTo;
        }
        #endregion

        #region Validator
        public sealed class GetCarrersListQueryValidator : AbstractValidator<GetCarrersListQuery>
        {
            public GetCarrersListQueryValidator()
            {
                RuleFor(x => x.Language)
                    .MaximumLength(CareerEntity.MAX_LENGTH_LANGUAGE)
                    .WithErrorCode("1")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {CareerEntity.MAX_LENGTH_LANGUAGE}");

                RuleFor(x => x.Location)
                    .MaximumLength(CareerEntity.MAX_LENGTH_LOCATION)
                    .WithErrorCode("2")
                    .WithMessage($"{{PropertyName}} lenght cannot by greater than {CareerEntity.MAX_LENGTH_LOCATION}");
            }
        }
        #endregion
    }
}