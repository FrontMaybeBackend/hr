using hr.Domain.Entity;

namespace hr.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAll();
    Task<Employee> Create(Employee employee);
    Task DeleteEmployee(int id);

    Task<Employee?> FindEmployeeAsync(int id);
}