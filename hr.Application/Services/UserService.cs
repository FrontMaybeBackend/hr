using AutoMapper;
using hr.Application.Dto;
using hr.Application.Interfaces;
using hr.Domain.Entity;
using hr.Domain.Interfaces;

namespace hr.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserResponseDto> CreateUser(CreateUserDto createUserDto)
    {   
        var user = _mapper.Map<User>(createUserDto);
        await _userRepository.Create(user);
        return _mapper.Map<UserResponseDto>(user);
    }

}