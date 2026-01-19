using AutoMapper;
using hr.Application.Dto;
using hr.Domain.Entity;

namespace hr.Application.Mappings;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDto, Employee>();
        CreateMap<Employee, ResponseEmployeeDto>();
    }
    
}