using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Persistence.Repositories
{
    public class MissionReadRepository : ReadRepository<Domain.Entities.Mission>, IMissionReadRepository
    {
        public MissionReadRepository(MissionTrackingSystemDbContext context) : base(context)
        {
        }
    }
}
