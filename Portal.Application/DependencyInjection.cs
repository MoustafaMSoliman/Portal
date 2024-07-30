using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.Common.Behaviours;
using Portal.Application.Services.Authentication.Commands;
using Portal.Application.Services.Authentication.Common;
using System.Reflection;

namespace Portal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehaviour<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
