using Expense.API.Extensions;
using Expense.Application;
using Expense.Infrastructure;
using Expense.Infrastructure.Persistence;

using MassTransit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Custom Services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

//Add Mass Transit
builder.Services.AddAutoMapper(typeof(Program));

//Masstransit Configuration

builder.Services.AddMassTransit(config =>
{

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
    });
});

// OPTIONAL, but can be used to configure the bus options
builder.Services.AddOptions<MassTransitHostOptions>()
    .Configure(options =>
    {
                    // if specified, waits until the bus is started before
                    // returning from IHostedService.StartAsync
                    // default is false
        options.WaitUntilStarted = true;

                    // if specified, limits the wait time when starting the bus
        options.StartTimeout = TimeSpan.FromSeconds(10);

                    // if specified, limits the wait time when stopping the bus
        options.StopTimeout = TimeSpan.FromSeconds(30);
    });

var app = builder.Build();

app.MigrateDatabase<ExpenseContext>((context, services) =>
{
    var logger= services.GetService<ILogger<ExpenseContextSeed>>();
    ExpenseContextSeed.SeedAsync(context, logger).Wait();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
