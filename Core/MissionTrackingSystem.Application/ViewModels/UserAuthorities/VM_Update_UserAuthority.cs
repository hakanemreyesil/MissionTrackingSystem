using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.ViewModels.UserAuthorities
{
    public class VM_Update_UserAuthority
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AuthorityId { get; set; }
    }
}
