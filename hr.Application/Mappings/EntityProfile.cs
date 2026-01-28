using Application.Dto;
using AutoMapper;
using hr.Domain.Entity;

namespace Application.Mappings;

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