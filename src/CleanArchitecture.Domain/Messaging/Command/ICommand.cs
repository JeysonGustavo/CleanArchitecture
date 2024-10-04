using CleanArchitecture.Domain.Common.App;
using MediatR;

namespace CleanArchitecture.Domain.Messaging.Command
{
    public interface ICommand : IRequest<ApplicationResult>
    {
    }
}
