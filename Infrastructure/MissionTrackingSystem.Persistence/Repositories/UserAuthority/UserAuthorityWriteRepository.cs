using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Domain.Entities;
using MissionTrackingSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Persistence.Repositories
{
    public class UserAuthorityWriteRepository : WriteRepository<UserAuthority>, IUserAuthorityWriteRepository
    {
        public UserAuthorityWriteRepository(MissionTrackingSystemDbContext context) : base(context)
        {
        }
    }
}
