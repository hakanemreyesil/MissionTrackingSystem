using MissionTrackingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Domain.Entities
{
    public class UserAuthority: BaseEntity
    {
        
        
        public Guid UserId { get; set; }
        public Guid AuthorityId { get; set; }
        public User User { get; set; }
        public Authority Authority { get; set; }
    }
}
