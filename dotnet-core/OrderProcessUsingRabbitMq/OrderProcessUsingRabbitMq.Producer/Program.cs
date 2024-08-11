using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.RabbitMQ;
using Publisher.RabbitMQ.Connection;
using Publisher.Service;

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

/*
 * docker command
 * 1- docker login --username your_username_here
 * 2- docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
 */