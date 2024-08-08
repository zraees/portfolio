using Microsoft.EntityFrameworkCore;
using OrderProcessUsingRabbitMq.Data;
using OrderProcessUsingRabbitMq.RabbitMQ;
using OrderProcessUsingRabbitMq.RabbitMQ.Connection;
using OrderProcessUsingRabbitMq.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderDBContext>(ctx =>
{
    ctx.UseInMemoryDatabase("OrderProcessDB");
});
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSingleton<IRabbitMqConnection>(new RabbitMqConnection());
builder.Services.AddScoped<IMessageProducer, RabbitMqProducer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
