using MissionTrackingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.Repositories
{
    public interface IUserReadRepository :IReadRepository<User>
    {
    }
}
