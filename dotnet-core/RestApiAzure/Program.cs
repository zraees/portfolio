using Microsoft.EntityFrameworkCore;
using RestApiAzure.Middleware;
using RestApiAzure.Models;
using RestApiAzure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeDBContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDB"));
});

builder.Services.AddScoped<IEmployeeService, EmployeeService>();


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

app.UseMiddleware<CustomeMiddleware>();

app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
