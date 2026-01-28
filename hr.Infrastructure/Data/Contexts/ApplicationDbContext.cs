using Microsoft.EntityFrameworkCore;

namespace hr.Infrastructure.Data.Contexts;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Domain.Entity.User> Users { get; set; }
    public DbSet<Domain.Entity.Employee> Employees { get; set; }
}