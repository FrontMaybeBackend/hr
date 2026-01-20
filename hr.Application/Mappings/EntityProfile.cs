using AutoMapper;
using hr.Application.Dto;
using hr.Domain.Entity;

namespace hr.Application.Mappings;

public class EntityProfile : Profile
{
    public EntityProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<Employee, EmployeeResponseDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<User, UserResponseDto>();
        CreateMap<User, OnboardingResponseDto>();
    }
    
}