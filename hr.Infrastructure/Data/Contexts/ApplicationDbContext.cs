using Microsoft.EntityFrameworkCore;

namespace hr.Infrastructure.Data.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options){}
    
    public DbSet<Domain.Entity.User> Users { get; set; }
    public DbSet<Domain.Entity.Employee> Employees { get; set; }
}