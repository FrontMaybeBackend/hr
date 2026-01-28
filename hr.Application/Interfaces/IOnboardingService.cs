using Application.Dto;

namespace Application.Interfaces;

public interface IOnboardingService
{
    public Task<OnboardingResponseDto> CreateOnboardingUser(CreateOnboardingDto createOnboardingDto);
}