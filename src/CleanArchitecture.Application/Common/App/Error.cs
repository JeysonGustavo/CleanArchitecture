using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Common.App
{
    [method: JsonConstructor]
    public class Error(string errorCode, string errorMessage)
    {
        #region Properties
        public static readonly Error None = new(string.Empty, string.Empty);

        public string ErrorCode { get; } = errorCode;
        public string ErrorMessage { get; } = errorMessage;
        #endregion
    }
}
