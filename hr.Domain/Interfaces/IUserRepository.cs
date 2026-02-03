using hr.Domain.Entity;

namespace hr.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> Create(User user);
    
    Task<User?> GetUserByEmail(string email);
}