using CleanArchitecture.Domain.Common.App;
using MediatR;

namespace CleanArchitecture.Domain.Messaging.Command
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, ApplicationResult> where TCommand : ICommand
    {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        new Task<ApplicationResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
