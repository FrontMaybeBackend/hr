using hr.Application.Employee;
using hr.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;


namespace hr.Infrastructure.Employee;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _dbContext;

    public EmployeeRepository(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Domain.Entity.Employee>> GetAll()
    {
        return await _dbContext.Employees.ToListAsync<Domain.Entity.Employee>();
    }
}
