using CleanArchitecture.Application.Messaging.Query;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCareerById
{
    public sealed record GetCareerByIdQuery(int Id) : IQuery
    {
    }
}