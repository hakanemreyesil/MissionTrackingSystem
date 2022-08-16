using MissionTrackingSystem.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Domain.Entities
{
    public class Department: BaseEntity
    {
        
        public string DepartmentName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
