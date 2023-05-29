using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

namespace HealthyApp.Infra.Repository
{
	public class LevelRepository : GenericRespository<Level>, ILevelRepository
    {
        public LevelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
