using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MissionTrackingSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Persistence
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MissionTrackingSystemDbContext>
    {
        public MissionTrackingSystemDbContext CreateDbContext(string[] args)
        {
           
            DbContextOptionsBuilder<MissionTrackingSystemDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
