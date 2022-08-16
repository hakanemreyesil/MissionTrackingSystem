using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MissionTrackingSystem.Domain.Entities;
using MissionTrackingSystem.Domain.Entities.Common;
using MissionTrackingSystem.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Persistence.Contexts
{
    public class MissionTrackingSystemDbContext : IdentityDbContext<AppUser,Approle,string>
    {
        public MissionTrackingSystemDbContext(DbContextOptions options) : base(options)
        {        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthority> UserAuthorities { get; set; }
        public DbSet<UserMission> UserMissions { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added=> data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified=> data.Entity.UpdatedDate= DateTime.UtcNow ,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
