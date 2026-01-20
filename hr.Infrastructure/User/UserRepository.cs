using hr.Domain.Interfaces;
using hr.Infrastructure.Data.Contexts;

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
}