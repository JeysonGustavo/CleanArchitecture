using CleanArchitecture.Application.Common.Messaging.Query;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCareerById
{
    public sealed record GetCareerByIdQuery(int Id) : IQuery
    {
    }
}