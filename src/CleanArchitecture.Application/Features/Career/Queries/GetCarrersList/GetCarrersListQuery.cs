using CleanArchitecture.Application.Common.Messaging.Query;
using CleanArchitecture.Application.Contracts.Request.Career;

namespace CleanArchitecture.Application.Features.Career.Queries.GetCarrersList
{
    public sealed record GetCarrersListQuery(CareerFilterListRequest Request) : IQuery
    {
    }
}