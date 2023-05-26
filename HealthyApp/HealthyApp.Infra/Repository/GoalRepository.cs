using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Infra.Repository
{
	public class GoalRepository : GenericRespository<Goal>, IGoalRepository
    {
        private readonly DbSet<Goal> _dbSet;

        public GoalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Goal>();
        }

        public async Task<IEnumerable<Goal>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(q=>q.User.Id == userId).ToListAsync();
        }

        public async Task<Goal> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(q => q.User.Id == id).Include("Progress").FirstOrDefaultAsync();
        }
    }
}
