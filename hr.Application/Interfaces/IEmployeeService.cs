using Application.Dto;
using hr.Domain.Entity;

namespace Application.Interfaces;

public interface IEmployeeService
{
    public Task<List<Employee>> GetEmployees();

    public Task<EmployeeResponseDto> CreateEmployee(CreateEmployeeDto createEmployeeDto);
    
    public Task DeleteEmployee(int id);
    
}