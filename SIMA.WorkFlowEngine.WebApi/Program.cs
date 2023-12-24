using Microsoft.AspNetCore.Authorization;
using SIMA.Framework.Common.Security;
using SIMA.Framework.WebApi;
using SIMA.Framework.WebApi.ConfigurationExtention;
using SIMA.WorkFlowEngine.Application.ConfigurationExtensions;
using SIMA.WorkFlowEngine.Application.Query.ConfigurationExtensions;
using SIMA.WorkFlowEngine.Persistance.EF.ConfigurationExtentions;
using SIMA.WorkFlowEngine.Persistance.EF.Read.ConfigurationExtentions;
using SIMA.WorkFlowEngine.WebApi.ConfigurationExtention;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<TokenModel>(
    builder.Configuration.GetSection(
        key: nameof(TokenModel)));
builder.Services.AddSingleton<IAuthorizationHandler, PermissionsAuthorizationHandler>();
builder.Services.RegisterAuthentication(builder.Configuration)
                .AddCommandHandlerServices()
                .RegisterApplicationServices()
                .RegisterReadDbContext(builder.Configuration)
                .RegisterQueryRepositories()
                .RegisterWriteDbContext(builder.Configuration)
                .RegisterCommandRepository()
                .RegisterUnitOfWork()
                .AddEndpointsApiExplorer()
                .RegisterQueryHandlerService()
                .AddSimaSwagger()
                //.RegisterDomainServices()
                .RegisterConventions();

//services.AddResponseCompression(option =>
//{
//    option.EnableForHttps = true;
//});

var app = builder.Build();
//CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
