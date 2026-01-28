using Application.Dto;
using Application.Interfaces;
using AutoMapper;

namespace Application.Services;

public class OnboardingService(IUserService userService, IEmployeeService employeeService) : IOnboardingService
{
    public async Task<OnboardingResponseDto> CreateOnboardingUser(CreateOnboardingDto createOnboardingDto)
    {
       var user = await userService.CreateUser(createOnboardingDto.CreateUserDto);
       createOnboardingDto.CreateEmployeeDto.UserId = user.Id; 
       var employee = await employeeService.CreateEmployee(createOnboardingDto.CreateEmployeeDto);
       return new OnboardingResponseDto
       {
           User = user,
           Employee = employee
       };
    }
}