using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.ViewModels.Missions
{
    public class VM_Update_Mission
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
    }
}
