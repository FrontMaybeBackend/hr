using hr.Domain.Interfaces;
using hr.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;


namespace hr.Infrastructure.Employee;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Domain.Entity.Employee>> GetAll()
    {
        return await _dbContext.Employees.ToListAsync<Domain.Entity.Employee>();
    }

    public async Task<Domain.Entity.Employee> Create(Domain.Entity.Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = _dbContext.Employees.Find(id);
        _dbContext.Employees.Remove(employee);
        await _dbContext.SaveChangesAsync();
    }
}
