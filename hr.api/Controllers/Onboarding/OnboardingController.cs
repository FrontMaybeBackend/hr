using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace hr.Controllers.Onboarding;

[ApiController]
[Route("[controller]")]
public class OnboardingController : ControllerBase
{
    private readonly IOnboardingService _onboardingService;

    public OnboardingController(IOnboardingService onboardingService)
    {
        _onboardingService = onboardingService;
    }
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUserAndEmployee(CreateOnboardingDto createOnboardingDto)
    {
        var result = await  _onboardingService.CreateOnboardingUser(createOnboardingDto);
        return Ok(result);
    }
}