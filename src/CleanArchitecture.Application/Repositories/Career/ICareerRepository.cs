using CleanArchitecture.Application.Contracts.Request.Career;
using CleanArchitecture.Application.Contracts.Response.Career;
using CleanArchitecture.Domain.Entities.Career;

namespace CleanArchitecture.Application.Repositories.Career
{
    public interface ICareerRepository
    {
        /// <summary>
        /// Create Career
        /// </summary>
        /// <param name="career"></param>
        /// <returns></returns>
        Task<CareerEntity> CreateCareerAsync(CareerEntity career);

        /// <summary>
        /// Update Career
        /// </summary>
        /// <param name="career"></param>
        /// <returns></returns>
        Task<bool> UpdateCareerAsync(CareerEntity career);

        /// <summary>
        /// Delete Career
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCareerAsync(int id);

        /// <summary>
        /// Get Career By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CareerResponse?> GetCareerByIdAsync(int id);

        /// <summary>
        /// Get Carrers List Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<CareerResponse>> GetCarrersListAsync(CareerListRequest request);
    }
}
