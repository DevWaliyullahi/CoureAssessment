using FluentValidation;

namespace CoureAssessment.Validators
{
    public class PhoneNumberValidator : AbstractValidator<string>
    {
        public PhoneNumberValidator()
        {
            RuleFor(phone => phone)
                .NotEmpty()
                .WithMessage("Phone number cannot be empty")
                .MaximumLength(20)
                .WithMessage("Phone number is too long (maximum 20 digits)")
                .Matches(@"^\d+$")
                .WithMessage("Phone number must contain only digits (0-9)");
        }
    }
}
