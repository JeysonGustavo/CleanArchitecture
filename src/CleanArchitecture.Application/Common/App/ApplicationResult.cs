namespace CleanArchitecture.Application.Common.App
{
    public class ApplicationResult
    {
        #region Properties
        public bool IsSuccess { get; }
        public object? Data { get; }
        public List<Error>? Errors { get; } = [];
        #endregion

        #region Constructor
        public ApplicationResult(bool isSuccess, Error error) 
        {
            IsSuccess = isSuccess;
            Errors.Add(error);
        }

        public ApplicationResult(object? data, bool isSuccess, Error error)
        {
            Data = data;
            IsSuccess = isSuccess;
            Errors.Add(error);
        }

        public ApplicationResult(bool isSuccess, List<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public ApplicationResult(object? data, bool isSuccess, List<Error> errors)
        {
            Data = data;
            IsSuccess = isSuccess;
            Errors = errors;
        }
        #endregion

        #region Methods
        public static ApplicationResult Success() => new(true, Error.None);

        public static ApplicationResult Success(object data) => new(data, true, Error.None);

        public static ApplicationResult Failure(Error error) => new (false, error);

        public static ApplicationResult Failure(List<Error> errors) => new(false, errors);

        public static ApplicationResult Failure(object data, Error error) => new(data, false, error);

        public static ApplicationResult Failure(object data, List<Error> errors) => new(data, false, errors);

        public bool HasErrors() => Errors is not null && Errors.Count > 0;
        #endregion
    }
}
