using DNI.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebTokenGenerator.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddLogging()
                .RegisterServiceDependencies(new[] { typeof(ServiceCollectionExtensions).Assembly }, ServiceLifetime.Transient, new[] { "Server" });
        }
    }
}
