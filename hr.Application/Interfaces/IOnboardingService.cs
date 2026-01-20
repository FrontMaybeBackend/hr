using hr.Application.Dto;

namespace hr.Application.Interfaces;

public interface IOnboardingService
{
    public Task<OnboardingResponseDto> CreateOnboardingUser(CreateOnboardingDto createOnboardingDto);
}