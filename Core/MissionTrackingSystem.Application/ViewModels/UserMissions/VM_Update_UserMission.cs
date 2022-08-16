using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.ViewModels.UserMissions
{
    public class VM_Update_UserMission
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MissionId { get; set; }
    }
}
