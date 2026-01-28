using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace hr.Controllers.Onboarding;

[ApiController]
[Route("[controller]")]
public class OnboardingController(IOnboardingService onboardingService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUserAndEmployee(CreateOnboardingDto createOnboardingDto)
    {
        var result = await  onboardingService.CreateOnboardingUser(createOnboardingDto);
        return Ok(result);
    }
}