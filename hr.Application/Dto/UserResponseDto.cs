using hr.Domain.Enums;

namespace Application.Dto;

public class UserResponseDto
{
   public int Id { get; set; }
   public string Username { get; set; }
   public string email { get; set; }
   public string CreatedAt { get; set; }
   public bool isActive { get; set; }
   public UserRole Role { get; set; }
  
}