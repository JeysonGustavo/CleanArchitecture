namespace CleanArchitecture.Domain.Common.Exceptions
{
    public sealed class NotFoundException(string message) : Exception(message)
    {
    }
}
