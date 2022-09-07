
using Expense.Application.Contracts.Persistance;
using Expense.Infrastructure.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expense.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        var assemblyName = typeof(ExpenseContext).Namespace;
        services.AddDbContext<ExpenseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString"), options => options.MigrationsAssembly(assemblyName));
        });

        services.AddScoped<ExpenseContext, ExpenseContext>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        return services;
    }
}
