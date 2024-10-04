using CleanArchitecture.Application.Common.App;
using MediatR;

namespace CleanArchitecture.Application.Messaging.Query
{
    public interface IQuery : IRequest<ApplicationResult>
    {
    }
}
