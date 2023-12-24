using Microsoft.Extensions.DependencyInjection;
using SIMA.Framework.Core.Domain;
using SIMA.Framework.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SIMA.Auth.DomainService.ConfigurationExtensions
{
    public static class ConfigurationExtension
    {
        //public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        //{
        //    return services.Scan(scan =>
        //           scan.FromAssemblyOf<ConfigurationAttributeService>()
        //           .AddClasses(classes => classes.AssignableTo(typeof(IDomainService)))
        //           .AsImplementedInterfaces()
        //           .WithScopedLifetime());
        //}
    }
}
