using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace Application.Services;

public class EmployeeService(IEmployeeRepository repository, AutoMapper.IMapper mapper) : IEmployeeService
{
    public Task<List<Employee>> GetEmployees()
    {
        return repository.GetAll();
    }

    public async Task<EmployeeResponseDto> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var employee = mapper.Map<Employee>(createEmployeeDto);
        await repository.Create(employee);
        return mapper.Map<EmployeeResponseDto>(employee);
    }

    public async Task DeleteEmployee(int id)
    {
       var employee = await  repository.FindEmployeeAsync(id);
       if (employee is null)
       {
           throw new NotFoundException($"Employee with id {id} not found");
       }
       await repository.DeleteEmployee(id);
    }
    
}