using Microsoft.EntityFrameworkCore;
using MyAppService.Domain.Interfaces.Repositories;
using MyAppService.Domain.Interfaces.Services;
using MyAppService.Application.Services;
using MyAppService.Domain.Common;
using MyAppService.Infrastructure.Data;
using MyAppService.Infrastructure.Repositories;
using MyAppService.Application;
using MyAppService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
Console.WriteLine(env);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);

builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DI
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// CORS
builder.Services.AddCors(opt => 
    { 
        opt.AddPolicy("AllowClient", policy => 
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); 
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowClient");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
