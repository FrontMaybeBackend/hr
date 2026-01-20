using hr.Domain.Enums;

namespace hr.Domain.Entity;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    public UserRole Role { get; set; }
    
    public Employee? Employee { get; set; }
    
}