using CleanArchitecture.Application.Common.App;
using MediatR;

namespace CleanArchitecture.Application.Common.Messaging.Query
{
    public interface IQuery : IRequest<ApplicationResult>
    {
    }
}
