using HealthyApp.Domain.Models;

namespace HealthyApp.Domain.Interfaces
{
	public interface IHealthyUserRepository : IGenericRepository<User>
	{
		Task<User> GetByIdWithGoalsLevel(int id, CancellationToken cancellationToken);
		
		Task<User> GetByAspNetUserIdWithLevelRewards(string aspNetUserId, CancellationToken cancellationToken);
	}
}
