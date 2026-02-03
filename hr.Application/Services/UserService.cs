using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Jwt;
using Application.Interfaces.Password;
using AutoMapper;
using FluentValidation;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace Application.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper,
    IValidator<CreateUserDto> validator,
    ICustomPasswordHasher customPasswordHasher,
    ICreateJwtToken tokenProvider)
    : IUserService
{
    public async Task<UserResponseDto> CreateUser(CreateUserDto createUserDto)
    {
        var validationResult = await validator.ValidateAsync(createUserDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var existingUser = await userRepository.GetUserByEmail(createUserDto.Email);
        if (existingUser != null)
        {
            throw new ExistsException("User with this email already exists");
        }

        var user = new User
        {
            Username = createUserDto.Username,
            Password = customPasswordHasher.HashedPassword(createUserDto.Password),
            Email = createUserDto.Email,
            CreatedAt = DateTime.Now,
            Role = createUserDto.Role,
            IsActive = true
        };
        await userRepository.Create(user);
        return mapper.Map<UserResponseDto>(user);
    }

    public async Task<LoginUserResponseDto> LoginUser(LoginUserDto loginUserDto)
    {
        var user = await userRepository.GetUserByEmail(loginUserDto.Email);
        if (user is null)
        {
            throw new NotFoundException("User with this credentials doesn't exist");
        }

        var token = tokenProvider.Create(user);
        return new LoginUserResponseDto
        {
            Message = "Success",
            Token = token,
        };
    }
}