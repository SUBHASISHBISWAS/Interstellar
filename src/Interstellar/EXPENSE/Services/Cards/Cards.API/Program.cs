using Cards.API.EventBusConsumer;
using Cards.API.HostedService;
using Cards.Application;
using Cards.Infrastructure;

using EventBus.Messages.Common;

using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custom Service Registration
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


//

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<CardTransactionUpdateConsumer>();
//Mass Transit

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<CardTransactionUpdateConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstants.CardUpdateQueue, c =>
        {
            c.ConfigureConsumer<CardTransactionUpdateConsumer>(ctx);
        });
    });

});

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

builder.Services.AddSingleton<IWorker, Worker>();

builder.Services.AddHostedService<CardUpdateHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
