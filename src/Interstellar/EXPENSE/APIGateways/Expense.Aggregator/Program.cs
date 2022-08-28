using Expense.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custom Service

builder.Services.AddHttpClient<ICardService, CardService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:CardUrl"]);
});

builder.Services.AddHttpClient<IExpenseService, ExpenseService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:ExpenseUrl"]);
});


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
