namespace CleanArchitecture.Domain.Common.App
{
    public class ApplicationResult
    {
        #region Properties
        public bool Success { get; set; }
        public object? ResultData { get; set; }
        public List<Error>? Errors { get; set; } = new List<Error>();
        #endregion

        #region Constructor
        public ApplicationResult() { }
        #endregion

        #region Methods
        public ApplicationResult WithSuccess()
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetSucces();
            return applicationResult;
        }

        public ApplicationResult WithSuccess(object resultData)
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetSucces(resultData);
            return applicationResult;
        }

        public ApplicationResult WithError(string errorCode, string errorMessage)
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetError(new Error(errorCode, errorMessage));
            return applicationResult;
        }

        public ApplicationResult WithError(IEnumerable<Error> errors)
        {
            var applicationResult = new ApplicationResult();
            applicationResult.SetErrors(errors);
            return applicationResult;
        }

        public void SetSucces()
        {
            Success = true;
            ResultData = null;
            Errors = null;
        }

        public void SetSucces(object resultData)
        {
            Success = true;
            ResultData = resultData;
            Errors = null;
        }

        public void SetError(Error error)
        {
            Success = false;
            ResultData = null;
            Errors = Errors ?? new List<Error>();
            Errors.Add(error);
        }

        public void SetErrors(IEnumerable<Error> errors)
        {
            Success = false;
            ResultData = null;
            Errors = errors.ToList();
        }

        public bool HasErrors() => Errors is null ? false : Errors.Count() > 0;
        #endregion
    }
}
