using System.Text;
using Application.Interfaces;
using Application.Interfaces.Jwt;
using Application.Interfaces.Password;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using FluentValidation;
using hr.Domain.Interfaces;
using hr.Extensions;
using hr.Infrastructure.Data.Contexts;
using hr.Infrastructure.Employee;
using hr.Infrastructure.Jwt;
using hr.Infrastructure.User;
using hr.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenAuth();
builder.Services.AddDbContext<ApplicationDbContext>(x =>
    x.UseMySql(
        builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)),
        new MySqlServerVersion(new Version(9, 5, 0))
    )
);

//Jwt
builder.Services.AddSingleton<TokenProvider>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = true;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JwtToken"])),
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
        }; 
    });



//Mapper
builder.Services.AddAutoMapper(typeof(EntityProfile));

//Employee
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICreateJwtToken, TokenProvider>();
//Onboarding
builder.Services.AddScoped<IOnboardingService, OnboardingService>();

//Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();

//PasswordHasher
builder.Services.AddScoped<ICustomPasswordHasher, CustomPasswordHaser>();

//Handler
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();