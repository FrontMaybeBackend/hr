namespace hr.Application.Employee;
using hr.Domain.Entity;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAll();
}