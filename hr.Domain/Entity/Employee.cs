namespace hr.Domain.Entity;

public class Employee
{
    public int  EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateOnly Since { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}