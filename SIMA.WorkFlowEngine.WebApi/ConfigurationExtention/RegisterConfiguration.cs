using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.IdentityModel.Tokens;
using SIMA.Framework.Common.Security;
using SIMA.WorkFlowEngine.Application.WorkFlowActor.Mappers;
using SIMA.WorkFlowEngine.WebApi.Controllers.WorkFlowActors.V1;
using SIMA.WorkFlowEngine.WebApi.Conventions;
using System.Reflection;
using System.Text;

namespace SIMA.WorkFlowEngine.WebApi.ConfigurationExtention
{
    public static class RegisterConfiguration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(c =>
            {
                c.Lifetime = ServiceLifetime.Scoped;
                c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
        public static IServiceCollection RegisterConventions(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new ModelConvention());

            }).PartManager.ApplicationParts.Add(new AssemblyPart(typeof(WorkFlowActorsController).Assembly));
            return services;
        }
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(WorkFlowActorMapper).Assembly);
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
        public static IServiceCollection RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            TokenModel token = new();
            configuration.GetSection(nameof(TokenModel))
                .Bind(token);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = token.Issuer,
                    ValidIssuer = token.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.SigningKey))
                };
            });
            return services;
        }
    }
}
