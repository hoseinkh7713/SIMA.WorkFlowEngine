using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sima.Framework.Core.Repository;
using SIMA.Framework.Core.Repository;
using SIMA.Framework.Infrastructure.Data;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlow.Interface;
using SIMA.WorkFlowEngine.Domain.Models.WorkFlowActor.Interface;
using SIMA.WorkFlowEngine.Persistance.EF.Persistence;
using SIMA.WorkFlowEngine.Persistance.EF.Repositories.WorkFlowActorRepository;
using SIMA.WorkFlowEngine.Persistance.EF.Repositories.WorkFlowRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Persistance.EF.ConfigurationExtentions
{
    public static class ConfigurationExtention
    {
        public static IServiceCollection RegisterWriteDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DbContext, WorkFlowContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("WorkFlow")
                    ));
        }
        public static IServiceCollection RegisterCommandRepository(this IServiceCollection services)
        {
            return services.Scan(scan =>
                   scan.FromAssemblyOf<WorkFlowActorRepository>()
                   .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                   .AsImplementedInterfaces()
                   .WithScopedLifetime());
        }
        public static IServiceCollection RegisterUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
