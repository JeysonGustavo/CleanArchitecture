using CleanArchitecture.Application.Contracts.Response.Career;
using CleanArchitecture.Application.Features.Career.Commands.CreateCareer;
using CleanArchitecture.Application.Features.Career.Commands.UpdateCareer;
using CleanArchitecture.Domain.Entities.Career;
using Mapster;

namespace CleanArchitecture.API.Mappers
{
    public static class MappingProfile
    {
        #region ConfigureMapster
        public static void ConfigureMapster()
        {
            #region Entities
            TypeAdapterConfig<CreateCareerCommand, CareerEntity>.NewConfig().MapToConstructor(true);
            TypeAdapterConfig<UpdateCareerCommand, CareerEntity>.NewConfig().MapToConstructor(true);
            #endregion

            #region Request
            #endregion

            #region Response
            TypeAdapterConfig<CareerEntity, CareerResponse>.NewConfig().MapToConstructor(true);
            #endregion
        }
        #endregion
    }
}
