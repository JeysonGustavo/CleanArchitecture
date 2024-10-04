using FluentValidation;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Domain.Common.Entities
{
    public abstract class BaseEntity
    {
        #region Properties
        public int Id { get; private set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();
        #endregion

        #region Methods
        public abstract void Validate();

        public void SetId(int id) => Id = id;

        internal virtual void ValidateEntity()
        {
            if (ValidationResult.Errors.Count > 0)
                throw new ValidationException(ValidationResult.Errors);
        }
        #endregion
    }
}
