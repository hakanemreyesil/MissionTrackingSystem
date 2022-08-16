using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Application.ViewModels.Users
{
    public class VM_Update_User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
