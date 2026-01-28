namespace Application.Dto;

public class CreateEmployeeDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateOnly Since { get; set; }
    
    public int?  UserId { get; set; }
}