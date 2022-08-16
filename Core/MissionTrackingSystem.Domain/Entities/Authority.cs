using MissionTrackingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Domain.Entities
{
    public class Authority: BaseEntity
    {
       
        public string AuthorityName { get; set; }
        public ICollection<UserAuthority> UserAuthorities { get; set; }
    }
}
