using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers.User;
[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUser(CreateUserDto createUserDto)
    {
        var result = await  userService.CreateUser(createUserDto);
        return Ok(result);
    }
}