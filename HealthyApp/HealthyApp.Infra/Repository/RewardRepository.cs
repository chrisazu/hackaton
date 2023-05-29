using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

namespace HealthyApp.Infra.Repository
{
	public class RewardRepository : GenericRespository<Reward>, IRewardRepository
    {
        public RewardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
