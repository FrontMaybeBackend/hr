using AutoMapper;
using hr.Application.Interfaces;
using hr.Application.Mappings;
using hr.Application.Services;
using hr.Domain.Interfaces;
using hr.Infrastructure.Contexts;
using hr.Infrastructure.Employee;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDbContext>(x =>
    x.UseMySql(
        builder.Configuration.GetConnectionString(nameof(EmployeeDbContext)),
        new MySqlServerVersion(new Version(9, 5, 0)) 
    )
);

builder.Services.AddAutoMapper(typeof(EmployeeProfile));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();