using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Persistence.Repositories
{
    public class MissionWriteRepository : WriteRepository<Domain.Entities.Mission>, IMissionWriteRepository
    {
        public MissionWriteRepository(MissionTrackingSystemDbContext context) : base(context)
        {
        }
    }
}
