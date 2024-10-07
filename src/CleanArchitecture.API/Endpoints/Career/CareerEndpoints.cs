using CleanArchitecture.API.Filters;
using CleanArchitecture.Application.Contracts.Request.Career;
using CleanArchitecture.Application.Features.Career.Commands.CreateCareer;
using CleanArchitecture.Application.Features.Career.Commands.DeleteCareer;
using CleanArchitecture.Application.Features.Career.Commands.UpdateCareer;
using CleanArchitecture.Application.Features.Career.Queries.GetCareerById;
using CleanArchitecture.Application.Features.Career.Queries.GetCarrersList;
using CleanArchitecture.Application.Repositories.Career;
using MediatR;

namespace CleanArchitecture.API.Endpoints.Career
{
    public static class CareerEndpoints
    {
        public static void ConfigureCareerEndpoints(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("api/career/").WithTags("Career");

            #region CreateCareer
            groupBuilder.MapPost("CreateCareer", CreateCareer)
                .AddEndpointFilter<ValidatorFilter<CreateCareerCommand>>()
                .WithName("CreateCareer");
            #endregion

            #region UpdateCareer
            groupBuilder.MapPut("UpdateCareer", UpdateCareer)
                .AddEndpointFilter<ValidatorFilter<UpdateCareerCommand>>()
                .WithName("UpdateCareer");
            #endregion

            #region DeleteCareer
            groupBuilder.MapDelete("DeleteCareer/{id}", DeleteCareer)
                .WithName("DeleteCareer");
            #endregion

            #region GetCareerById
            groupBuilder.MapGet("GetCareerById/{id}", GetCareerById)
                .WithName("GetCareerById");
            #endregion

            #region GetCarrersList
            groupBuilder.MapPost("GetCarrersList", GetCarrersList)
                .WithName("GetCarrersList");
            #endregion
        }

        #region Methods
        private static async Task<IResult> CreateCareer(CreateCareerCommand command, ISender _sender)
            => TypedResults.Ok((await _sender.Send(command)).Data);

        private static async Task<IResult> UpdateCareer(UpdateCareerCommand command, ISender _sender)
            => TypedResults.Ok((await _sender.Send(command)).Data);

        private static async Task<IResult> DeleteCareer(int id, ISender _sender)
            => TypedResults.Ok((await _sender.Send(new DeleteCareerCommand(id))).Data);

        private static async Task<IResult> GetCareerById(int id, ISender _sender)
            => TypedResults.Ok((await _sender.Send(new GetCareerByIdQuery(id))).Data);

        //private static async Task<IResult> GetCareerById(int id, ICareerRepository _careerRepository)
        //    => TypedResults.Ok(await _careerRepository.GetCareerByIdAsync(id));

        private static async Task<IResult> GetCarrersList(CareerFilterListRequest request, ISender _sender)
            => TypedResults.Ok((await _sender.Send(new GetCarrersListQuery(request))).Data);
        #endregion
    }
}
