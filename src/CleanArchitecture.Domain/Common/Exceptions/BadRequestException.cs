namespace CleanArchitecture.Domain.Common.Exceptions
{
    public sealed class BadRequestException(string message) : Exception(message)
    {
    }
}
