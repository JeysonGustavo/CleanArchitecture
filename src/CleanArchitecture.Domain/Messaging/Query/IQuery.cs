using CleanArchitecture.Domain.Common.App;
using MediatR;

namespace CleanArchitecture.Domain.Messaging.Query
{
    public interface IQuery : IRequest<ApplicationResult>
    {
    }
}
