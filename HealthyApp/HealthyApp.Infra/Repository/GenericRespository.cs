using HealthyApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Infra.Repository
{
	public class GenericRespository<T> : IGenericRepository<T> where T :  class
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly DbSet<T> _dbSet;

		public GenericRespository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
		}

        public async Task<T> GetById(int id, CancellationToken cancellationToken)
		{
			return await _dbSet.FindAsync(id, cancellationToken);
		}

        public async Task<T> Create(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
			_dbContext.SaveChanges();
			return entity;
        }

        public async Task<T> Update(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
			await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}