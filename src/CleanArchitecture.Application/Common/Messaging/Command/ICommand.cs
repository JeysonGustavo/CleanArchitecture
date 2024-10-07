using CleanArchitecture.Application.Common.App;
using MediatR;

namespace CleanArchitecture.Application.Common.Messaging.Command
{
    public interface ICommand : IRequest<ApplicationResult>
    {
    }
}
