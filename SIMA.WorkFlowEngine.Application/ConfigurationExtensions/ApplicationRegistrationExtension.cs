using Microsoft.Extensions.DependencyInjection;
using SIMA.Framework.Core.Mediator;
using SIMA.WorkFlowEngine.Application.WorkFlowActor;


namespace SIMA.WorkFlowEngine.Application.ConfigurationExtensions
{
    public static class ApplicationRegistrationExtension
    {
        public static IServiceCollection AddCommandHandlerServices(this IServiceCollection services)
        {
            return services.Scan(scan =>
                scan.FromAssemblyOf<WorkFlowActorCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
