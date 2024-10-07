namespace CleanArchitecture.Application.Common.App
{
    public class ApplicationResult
    {
        #region Properties
        public bool IsSuccess { get; set; }
        public object? ResultData { get; set; }
        public List<Error>? Errors { get; set; } = [];
        #endregion

        #region Constructor
        public ApplicationResult() { }
        #endregion

        #region Methods
        public static ApplicationResult Success()
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetSucces();
            return applicationResult;
        }

        public static ApplicationResult Success(object resultData)
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetSucces(resultData);
            return applicationResult;
        }

        public static ApplicationResult Failure(string errorCode, string errorMessage)
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetError(new Error(errorCode, errorMessage));
            return applicationResult;
        }

        public static ApplicationResult Failure(IEnumerable<Error> errors)
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetErrors(errors);
            return applicationResult;
        }

        public void SetSucces()
        {
            IsSuccess = true;
            ResultData = null;
            Errors = null;
        }

        public void SetSucces(object resultData)
        {
            IsSuccess = true;
            ResultData = resultData;
            Errors = null;
        }

        public void SetError(Error error)
        {
            IsSuccess = false;
            ResultData = null;
            Errors ??= [];
            Errors.Add(error);
        }

        public void SetErrors(IEnumerable<Error> errors)
        {
            IsSuccess = false;
            ResultData = null;
            Errors = errors.ToList();
        }

        public bool HasErrors() => Errors is not null && Errors.Count > 0;
        #endregion
    }
}
