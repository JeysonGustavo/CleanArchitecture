using CleanArchitecture.Application.Contracts.Request.Career;
using CleanArchitecture.Application.Messaging.Query;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCarrersList
{
    public sealed record GetCarrersListQuery(CareerFilterListRequest Request) : IQuery
    {
    }
}