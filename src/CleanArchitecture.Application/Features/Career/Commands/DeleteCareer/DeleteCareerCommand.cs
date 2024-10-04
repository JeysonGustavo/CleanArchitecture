using CleanArchitecture.Application.Messaging.Command;

namespace CleanArchitecture.Application.Features.Career.Commands.DeleteCareer
{
    public sealed record DeleteCareerCommand(int Id) : ICommand { }
}