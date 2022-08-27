using Expense.Application;
using Expense.Infrastructure;
using Expense.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
//builder.Services.AddDbContext<ExpenseContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderingConnectionString"));
//});
// Configure Custom Services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
