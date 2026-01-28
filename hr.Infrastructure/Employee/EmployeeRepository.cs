using hr.Domain.Interfaces;
using hr.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;


namespace hr.Infrastructure.Employee;

public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeeRepository
{
    public async Task<List<Domain.Entity.Employee>> GetAll()
    {
        return await dbContext.Employees.ToListAsync<Domain.Entity.Employee>();
    }

    public async Task<Domain.Entity.Employee> Create(Domain.Entity.Employee employee)
    {
        await dbContext.Employees.AddAsync(employee);
        await dbContext.SaveChangesAsync();
        return employee;
    }

    public async Task<Domain.Entity.Employee?> FindEmployeeAsync(int id)
    {
        return await dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = dbContext.Employees.Find(id);
        dbContext.Employees.Remove(employee);
        await dbContext.SaveChangesAsync();
    }
}
