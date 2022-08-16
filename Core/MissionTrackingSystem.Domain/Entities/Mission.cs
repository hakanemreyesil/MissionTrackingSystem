using MissionTrackingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Domain.Entities
{
    public class Mission : BaseEntity
    {
        
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<UserMission> UserMissions { get; set; }
    }
}
