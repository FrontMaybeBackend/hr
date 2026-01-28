using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace Application.Services;

public class UserService(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserDto> validator)
    : IUserService
{
    public async Task<UserResponseDto> CreateUser(CreateUserDto createUserDto)
    {   
        var validationResult = await validator.ValidateAsync(createUserDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var user = mapper.Map<User>(createUserDto);
        await userRepository.Create(user);
        return mapper.Map<UserResponseDto>(user);
    }

}