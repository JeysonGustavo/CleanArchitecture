using System.Text.Json.Serialization;

namespace CleanArchitecture.Domain.Common.App
{
    public class Error
    {
        #region Properties
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Constructor
        [JsonConstructor]
        public Error(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        #endregion
    }
}
