using MissionTrackingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Domain.Entities
{
    public class UserMission: BaseEntity
    {
       
        public Guid UserId { get; set; }
        public Guid MissionId { get; set; }
        public User User{ get; set; }
        public Mission Mission { get; set; }
        
    }
}
