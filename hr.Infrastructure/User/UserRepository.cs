using hr.Domain.Interfaces;
using hr.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace hr.Infrastructure.User;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Domain.Entity.User> Create(Domain.Entity.User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<Domain.Entity.User?> GetUserByEmail(string email)
    {
       var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
       return user;
    }
}