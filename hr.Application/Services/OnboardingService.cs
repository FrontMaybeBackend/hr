using AutoMapper;
using hr.Application.Dto;
using hr.Application.Interfaces;


namespace hr.Application.Services;

public class OnboardingService : IOnboardingService
{
    
    private readonly IUserService _userService;
    private readonly IEmployeeService _employeeService;

    public OnboardingService(IUserService userService, IEmployeeService employeeService, IMapper mapper)
    {
        _userService = userService;
        _employeeService = employeeService;
    }
    public async Task<OnboardingResponseDto> CreateOnboardingUser(CreateOnboardingDto createOnboardingDto)
    {
       var user = await _userService.CreateUser(createOnboardingDto.CreateUserDto);
       createOnboardingDto.CreateEmployeeDto.UserId = user.Id; 
       var employee = await _employeeService.CreateEmployee(createOnboardingDto.CreateEmployeeDto);
       return new OnboardingResponseDto
       {
           User = user,
           Employee = employee
       };
    }
}