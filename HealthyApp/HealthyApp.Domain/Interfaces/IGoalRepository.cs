using HealthyApp.Domain.Models;

namespace HealthyApp.Domain.Interfaces
{
    public interface IGoalRepository : IGenericRepository<Goal>
    {
        Task<IEnumerable<Goal>> GetByUserId(int userId, CancellationToken cancellationToken);

		Task<Goal> GetByIdWithProgress(int id, CancellationToken cancellationToken);
	}
}
