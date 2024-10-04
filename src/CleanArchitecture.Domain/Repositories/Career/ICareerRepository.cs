using CleanArchitecture.Domain.Entities.Career;

namespace CleanArchitecture.Domain.Repositories.Career
{
    public interface ICareerRepository
    {
        /// <summary>
        /// Create Career
        /// </summary>
        /// <param name="career"></param>
        /// <returns></returns>
        Task<CareerEntity> CreateCareer(CareerEntity career);
    }
}
