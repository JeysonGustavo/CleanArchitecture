using CleanArchitecture.Application.Common.Messaging.Command;

namespace CleanArchitecture.Application.Features.Career.Commands.DeleteCareer
{
    public sealed record DeleteCareerCommand(int Id) : ICommand { }
}