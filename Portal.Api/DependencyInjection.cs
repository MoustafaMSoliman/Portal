using Mapster;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portal.Api.Common.Errors;
using Portal.Api.Common.Mapping;

namespace Portal.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory,PortalProblemDetailsFactory>();
        services.AddMapping();
        return services;
    }
}
