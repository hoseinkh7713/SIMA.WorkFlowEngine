using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SIMA.Framework.Core.Mediator;
using SIMA.WorkFlowEngine.Application.Query.WorkFlowActor;
using SIMA.WorkFlowEngine.Application.WorkFlowActor.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.WorkFlowEngine.Application.Query.ConfigurationExtensions
{
    public static class ApplicationQueryRegistrationExtension
    {
        public static IServiceCollection RegisterQueryHandlerService(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(WorkFlowActorMapper).Assembly);
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services.Scan(scan =>
                    scan.FromAssemblyOf<WorkFlowActorQueryHandler>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }
    }
}
