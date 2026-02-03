namespace Application.Interfaces.Password;

public interface ICustomPasswordHasher
{
    public string HashedPassword(string password);
}
