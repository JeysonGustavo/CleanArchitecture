using CleanArchitecture.API.Filters;
using CleanArchitecture.Application.Features.Career.Commands.CreateCareer;
using MediatR;

namespace CleanArchitecture.API.Endpoints.Career
{
    public static class CareerEndpoints
    {
        public static void ConfigureCareerEndpoints(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("api/career/").WithTags("Career");

            #region CreateCareer
            groupBuilder.MapPost("CreateCareer", CreateCareer).AddEndpointFilter<ValidatorFilter<CreateCareerCommand>>().WithName("CreateCareer");
            #endregion
        }

        private static async Task<IResult> CreateCareer(CreateCareerCommand command, ISender _sender)
        {
            return TypedResults.Ok(await _sender.Send(command));
        }
    }
}
