
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApiCoreIdentitySample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//step:1 configure DBContext
builder.Services.AddDbContext<IdentityDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("IdentityDBSample") ??
        throw new InvalidOperationException("Connectionstring not found!"));
});

//step:2 add endpoints
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>
   {
       options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
       {
           In = Microsoft.OpenApi.Models.ParameterLocation.Header,
           Name = "Authorization",
           Type = SecuritySchemeType.ApiKey
       });
       options.OperationFilter<SecurityRequirementsOperationFilter>();
   });

var app = builder.Build();

//step:3
app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
