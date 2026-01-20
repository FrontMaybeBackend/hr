using hr.Application.Dto;
using hr.Domain.Entity;

namespace hr.Application.Interfaces;

public interface IUserService
{
    public Task<UserResponseDto> CreateUser(CreateUserDto createUserDto);
    
}