using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers.User;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUser(CreateUserDto createUserDto)
    {
        var result = await  _userService.CreateUser(createUserDto);
        return Ok(result);
    }
}