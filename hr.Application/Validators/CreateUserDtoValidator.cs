using FluentValidation;
using hr.Application.Dto;

namespace hr.Application.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{

    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Role is invalid");
        
    }
    
}