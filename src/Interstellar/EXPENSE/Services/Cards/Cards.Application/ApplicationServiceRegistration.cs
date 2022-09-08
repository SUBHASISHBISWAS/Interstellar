using System.Reflection;

using Cards.Application.Behaviours;
using Cards.Application.Features.Cards.EventHandlers;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Cards.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient<CardCreatedEventHandlers>();
        return services;
    }
}
