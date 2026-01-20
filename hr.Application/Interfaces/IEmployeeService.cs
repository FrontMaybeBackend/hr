using hr.Application.Dto;
using hr.Domain.Entity;

namespace hr.Application.Interfaces;

public interface IEmployeeService
{
    public Task<List<Employee>> GetEmployees();

    public Task<EmployeeResponseDto> CreateEmployee(CreateEmployeeDto createEmployeeDto);
    
    public Task DeleteEmployee(int id);
    
}