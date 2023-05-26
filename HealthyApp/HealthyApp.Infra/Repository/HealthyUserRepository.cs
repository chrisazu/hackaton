using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace HealthyApp.Infra.Repository
{
    public class HealthyUserRepository : GenericRespository<User>, IHealthyUserRepository
    {

        private readonly DbSet<User> _dbSet;
        public HealthyUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<User>();
        }

        public async Task<User> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include("Goals")
                .Include("Level")
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}
