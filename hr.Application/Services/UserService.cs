using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserDto> _validator;
    

    public UserService(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserDto> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<UserResponseDto> CreateUser(CreateUserDto createUserDto)
    {   
        var validationResult = await _validator.ValidateAsync(createUserDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var user = _mapper.Map<User>(createUserDto);
        await _userRepository.Create(user);
        return _mapper.Map<UserResponseDto>(user);
    }

}