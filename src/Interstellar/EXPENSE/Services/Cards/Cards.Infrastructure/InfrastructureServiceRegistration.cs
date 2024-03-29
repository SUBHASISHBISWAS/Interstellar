﻿
using Cards.Application.Contracts.Persistance;
using Cards.Infrastructure.Data;
using Cards.Infrastructure.Repository;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cards.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ICardContext, CardContext>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        return services;
    }
}
