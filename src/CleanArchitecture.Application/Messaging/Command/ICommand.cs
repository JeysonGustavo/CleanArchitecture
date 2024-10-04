using CleanArchitecture.Application.Common.App;
using MediatR;

namespace CleanArchitecture.Application.Messaging.Command
{
    public interface ICommand : IRequest<ApplicationResult>
    {
    }
}
