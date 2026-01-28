using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using FluentValidation;
using hr.Domain.Interfaces;
using hr.Infrastructure.Data.Contexts;
using hr.Infrastructure.Employee;
using hr.Infrastructure.User;
using hr.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(x =>
    x.UseMySql(
        builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)),
        new MySqlServerVersion(new Version(9, 5, 0)) 
    )
);

builder.Services.AddAutoMapper(typeof(EntityProfile));

//Employee
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


//Onboarding
builder.Services.AddScoped<IOnboardingService, OnboardingService>();

//Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();



var app = builder.Build();
app.UseExceptionHandler();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();