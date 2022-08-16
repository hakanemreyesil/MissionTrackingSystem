using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Domain.Entities.Identity;
using MissionTrackingSystem.Persistence.Contexts;
using MissionTrackingSystem.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<MissionTrackingSystemDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser,Approle>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase= false;
                options.Password.RequireUppercase= false;
            } ).AddEntityFrameworkStores<MissionTrackingSystemDbContext>();

            services.AddScoped<IAuthorityReadRepository, AuthorityReadRepository>();
            services.AddScoped<IAuthorityWriteRepository, AuthorityWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<IMissionReadRepository, MissionReadRepository>();
            services.AddScoped<IMissionWriteRepository, MissionWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserAuthorityReadRepository, UserAuthorityReadRepository>();
            services.AddScoped<IUserAuthorityWriteRepository, UserAuthorityWriteRepository>();
            services.AddScoped<IUserMissionReadRepository, UserMissionReadRepository>();
            services.AddScoped<IUserMissionWriteRepository, UserMissionWriteRepository>();
        }
    }
}
