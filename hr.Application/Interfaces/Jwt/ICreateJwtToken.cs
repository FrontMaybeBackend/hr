namespace Application.Interfaces.Jwt;

public interface ICreateJwtToken
{
    public string Create(hr.Domain.Entity.User user);
}