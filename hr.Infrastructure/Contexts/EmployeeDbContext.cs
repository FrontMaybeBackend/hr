
using Microsoft.EntityFrameworkCore;

namespace hr.Infrastructure.Contexts;

public class EmployeeDbContext : DbContext
{
    
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {}
    
    public DbSet<Domain.Entity.Employee> Employees { get; set; }
}