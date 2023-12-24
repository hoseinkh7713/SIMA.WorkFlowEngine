using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIMA.Framework.Core.Repository;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Persistence;
using SIMA.WorkFlowEngine.Persistance.EF.Read.Repositories.WorkFlowActor;


namespace SIMA.WorkFlowEngine.Persistance.EF.Read.ConfigurationExtentions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection RegisterReadDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<DbContext, WorkFlowReadContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("WorkFlow")));
        }
        public static IServiceCollection RegisterQueryRepositories(this IServiceCollection services)
        {
            return services.Scan(scan =>
                scan.FromAssemblyOf<WorkFlowActorQueryRepository>()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryRepository)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
