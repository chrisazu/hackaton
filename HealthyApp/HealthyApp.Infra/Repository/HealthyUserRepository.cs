using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HealthyApp.Domain.Interfaces;
using HealthyApp.Domain.Models;

namespace HealthyApp.Infra.Repository
{
    public class HealthyUserRepository : GenericRespository<User>, IHealthyUserRepository
    {
        public HealthyUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
