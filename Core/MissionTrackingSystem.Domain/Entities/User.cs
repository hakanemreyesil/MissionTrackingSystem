using MissionTrackingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Domain.Entities
{
    public class User: BaseEntity
    {
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<UserMission> UserMissions { get; set; }
        public ICollection<UserAuthority> UserAuthorities { get; set; }

    }
}
