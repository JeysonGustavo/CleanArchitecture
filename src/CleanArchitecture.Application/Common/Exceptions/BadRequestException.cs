﻿namespace CleanArchitecture.Application.Common.Exceptions
{
    public sealed class BadRequestException(string message) : Exception(message)
    {
    }
}
