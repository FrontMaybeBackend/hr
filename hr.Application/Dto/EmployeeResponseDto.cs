namespace Application.Dto;

public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly Since { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}