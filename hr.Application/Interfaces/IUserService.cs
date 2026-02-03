using Application.Dto;

namespace Application.Interfaces;

public interface IUserService
{
    public Task<UserResponseDto> CreateUser(CreateUserDto createUserDto);

    public Task<LoginUserResponseDto> LoginUser(LoginUserDto loginUserDto);

}